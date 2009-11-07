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

        public string ReadString()
        {
            UInt32 length = this.ReadValueU32();
            if (length >= 1024 * 1024)
            {
                throw new InvalidOperationException("somehow I doubt there is a >1MB string to be read");
            }

            return this.Stream.ReadStringASCII(length, true);
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

        public void WriteString(string value)
        {
            if (value == null || value.Length == 0)
            {
                this.WriteValueS32(0);
                return;
            }

            this.WriteValueS32(value.Length + 1);
            this.Stream.WriteStringASCII(value);
            this.Stream.WriteValueU8(0);
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
