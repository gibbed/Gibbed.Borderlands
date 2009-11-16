using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats
{
    public class SaveStream
    {
        private Stream Stream;
        private bool LittleEndian;

        public SaveStream(Stream stream, bool littleEndian)
        {
            this.Stream = stream;
            this.LittleEndian = littleEndian;
        }

        public Int32 ReadValueS32()
        {
            return this.Stream.ReadValueS32(this.LittleEndian);
        }

        public UInt32 ReadValueU32()
        {
            return this.Stream.ReadValueU32(this.LittleEndian);
        }

        public float ReadValueF32()
        {
            return this.Stream.ReadValueF32(this.LittleEndian);
        }

        public T ReadEnum<T>()
        {
            return this.Stream.ReadValueEnum<T>();
        }

        public string ReadString()
        {
            Int32 length = this.ReadValueS32();

            if (length == 0)
            {
                return "";
            }

            bool isUnicode = false;
            
            // stupid stupid stupid stupid stupid
            if (length < 0)
            {
                length = Math.Abs(length);
                isUnicode = true;
            }
            
            if (length >= 1024 * 1024)
            {
                throw new InvalidOperationException("somehow I doubt there is a >1MB string to be read");
            }

            if (isUnicode == true)
            {
                return this.Stream.ReadStringUTF16(this.LittleEndian, (uint)(length * 2), true);
            }
            else
            {
                return this.Stream.ReadStringASCII((uint)(length), true);
            }
        }

        public string ReadStaticString(UInt32 length)
        {
            return this.Stream.ReadStringASCII(length);
        }

        public byte[] ReadBuffer()
        {
            Int32 length = this.ReadValueS32();
            byte[] rez = new byte[length];
            this.Stream.Read(rez, 0, rez.Length);
            return rez;
        }

        public void WriteValueS32(Int32 value)
        {
            this.Stream.WriteValueS32(value, this.LittleEndian);
        }

        public void WriteValueU32(UInt32 value)
        {
            this.Stream.WriteValueU32(value, this.LittleEndian);
        }

        public void WriteValueF32(float value)
        {
            this.Stream.WriteValueF32(value, this.LittleEndian);
        }

        public void WriteEnum<T>(T value)
        {
            this.Stream.WriteValueEnum<T>(value);
        }

        public void WriteString(string value)
        {
            if (value == null || value.Length == 0)
            {
                this.WriteValueS32(0);
                return;
            }

            // I'm lazy, always write in UTF16 so I don't have to bother
            // checking if a string contains special characters that can't
            // be stored in ASCII.

            this.WriteValueS32(-(value.Length + 1));
            this.Stream.WriteStringUTF16(this.LittleEndian, value);
            this.Stream.WriteValueU16(0);
        }

        public void WriteStaticString(string value)
        {
            this.Stream.WriteStringASCII(value);
        }

        public void WriteBuffer(byte[] value)
        {
            this.WriteValueS32(value.Length);
            this.Stream.Write(value, 0, value.Length);
        }
    }
}
