/* Copyright (c) 2019 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */
using System;
using System.IO;
using System.Text;
using Gibbed.IO;

namespace Gibbed.Borderlands.FileFormats
{
    public class SaveStream
    {
        private readonly Stream _BaseStream;
        private readonly Endian _Endian;

        public SaveStream(Stream baseStream, Endian endian)
        {
            this._BaseStream = baseStream;
            this._Endian = endian;
        }

        public int ReadValueS32()
        {
            return this._BaseStream.ReadValueS32(this._Endian);
        }

        public uint ReadValueU32()
        {
            return this._BaseStream.ReadValueU32(this._Endian);
        }

        public float ReadValueF32()
        {
            return this._BaseStream.ReadValueF32(this._Endian);
        }

        public T ReadEnum<T>()
        {
            return this._BaseStream.ReadValueEnum<T>(this._Endian);
        }

        public string ReadString()
        {
            var length = this.ReadValueS32();
            if (length == 0)
            {
                return string.Empty;
            }

            bool isUnicode = false;
            
            if (length < 0)
            {
                length = -length;
                isUnicode = true;
            }
            
            if (length >= 1024 * 1024)
            {
                throw new InvalidOperationException("somehow I doubt there is a >1MB string to be read");
            }

            Encoding encoding;
            if (isUnicode == true)
            {
                encoding = this._Endian == Endian.Little ? Encoding.Unicode : Encoding.BigEndianUnicode;
                length *= 2;
            }
            else
            {
                encoding = Encoding.ASCII;
            }
            return this._BaseStream.ReadString(length, true, encoding);
        }

        public string ReadStaticString(int length)
        {
            return this._BaseStream.ReadString(length, Encoding.ASCII);
        }

        public byte[] ReadBuffer()
        {
            var length = this.ReadValueS32();
            return this._BaseStream.ReadBytes(length);
        }

        public void WriteValueS32(int value)
        {
            this._BaseStream.WriteValueS32(value, this._Endian);
        }

        public void WriteValueU32(uint value)
        {
            this._BaseStream.WriteValueU32(value, this._Endian);
        }

        public void WriteValueF32(float value)
        {
            this._BaseStream.WriteValueF32(value, this._Endian);
        }

        public void WriteEnum<T>(T value)
        {
            this._BaseStream.WriteValueEnum<T>(value, this._Endian);
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

            var encoding = this._Endian == Endian.Little ? Encoding.Unicode : Encoding.BigEndianUnicode;

            var bytes = encoding.GetBytes(value);

            this.WriteValueS32(-((bytes.Length / 2) + 1));
            this._BaseStream.WriteBytes(bytes);
            this._BaseStream.WriteValueU16(0, this._Endian);
        }

        public void WriteStaticString(string value)
        {
            this._BaseStream.WriteString(value, Encoding.ASCII);
        }

        public void WriteBuffer(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.WriteValueS32(value.Length);
            this._BaseStream.WriteBytes(value);
        }
    }
}
