using System;
using System.IO;
using System.Text;
using Gibbed.IO;

namespace Gibbed.Borderlands.FileFormats
{
    public class SaveStream
    {
        private Stream Stream;
        private Endian Endian;

        public SaveStream(Stream stream, Endian endian)
        {
            this.Stream = stream;
            this.Endian = endian;
        }

        public Int32 ReadValueS32()
        {
            return this.Stream.ReadValueS32(this.Endian);
        }

        public UInt32 ReadValueU32()
        {
            return this.Stream.ReadValueU32(this.Endian);
        }

        public float ReadValueF32()
        {
            return this.Stream.ReadValueF32(this.Endian);
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
                var encoding = this.Endian == Endian.Little ? Encoding.Unicode : Encoding.BigEndianUnicode;
                return this.Stream.ReadString((uint)(length * 2), true, encoding);
            }
            else
            {
                return this.Stream.ReadString((uint)(length), true, Encoding.ASCII);
            }
        }

        public string ReadStaticString(uint length)
        {
            return this.Stream.ReadString(length, Encoding.ASCII);
        }

        public byte[] ReadBuffer()
        {
            int length = this.ReadValueS32();
            byte[] rez = new byte[length];
            this.Stream.Read(rez, 0, rez.Length);
            return rez;
        }

        public void WriteValueS32(int value)
        {
            this.Stream.WriteValueS32(value, this.Endian);
        }

        public void WriteValueU32(uint value)
        {
            this.Stream.WriteValueU32(value, this.Endian);
        }

        public void WriteValueF32(float value)
        {
            this.Stream.WriteValueF32(value, this.Endian);
        }

        public void WriteEnum<T>(T value)
        {
            this.Stream.WriteValueEnum<T>(value);
        }

        public void WriteString(string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                this.WriteValueS32(0);
                return;
            }

            // I'm lazy, always write in UTF16 so I don't have to bother
            // checking if a string contains special characters that can't
            // be stored in ASCII.

            var encoding = this.Endian == Endian.Little ? Encoding.Unicode : Encoding.BigEndianUnicode;

            this.WriteValueS32(-(value.Length + 1));
            this.Stream.WriteString(value, encoding);
            this.Stream.WriteValueU16(0, this.Endian);
        }

        public void WriteStaticString(string value)
        {
            this.Stream.WriteString(value, Encoding.ASCII);
        }

        public void WriteBuffer(byte[] value)
        {
            this.WriteValueS32(value.Length);
            this.Stream.Write(value, 0, value.Length);
        }
    }
}
