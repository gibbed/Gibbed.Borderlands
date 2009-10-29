using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats
{
    public static partial class StreamHelpers
    {
        public static string ReadStringASCIIU32(this Stream stream)
        {
            UInt32 length = stream.ReadValueU32();
            if (length >= 1024 * 1024)
            {
                throw new InvalidOperationException("somehow I doubt there is a >1MB string to be read");
            }

            return stream.ReadStringASCII(length, true);
        }

        public static void WriteStringASCIIU32(this Stream stream, string value)
        {
            if (value.Length == 0)
            {
                stream.WriteValueS32(0);
                return;
            }

            stream.WriteValueS32(value.Length + 1);
            stream.WriteStringASCII(value);
            stream.WriteValueU8(0);
        }
    }
}
