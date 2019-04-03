using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class Mission
    {
        public class Unknown4
        {
            public string Unknown0;
            public UInt32 Unknown1;

            public void Deserialize(SaveStream input)
            {
                this.Unknown0 = input.ReadString();
                this.Unknown1 = input.ReadValueU32();
            }

            public void Serialize(SaveStream output)
            {
                output.WriteString(this.Unknown0);
                output.WriteValueU32(this.Unknown1);
            }
        }

        public string Name;
        public UInt32 Unknown1;
        public UInt32 Unknown2;
        public UInt32 Unknown3;
        public List<Unknown4> Unknown4s = new List<Unknown4>();

        public void Deserialize(SaveStream input)
        {
            this.Name = input.ReadString();
            this.Unknown1 = input.ReadValueU32();
            this.Unknown2 = input.ReadValueU32();
            this.Unknown3 = input.ReadValueU32();

            // States
            {
                uint count = input.ReadValueU32();
                this.Unknown4s.Clear();
                for (uint i = 0; i < count; i++)
                {
                    Unknown4 unknown3 = new Unknown4();
                    unknown3.Deserialize(input);
                    this.Unknown4s.Add(unknown3);
                }
            }
        }

        public void Serialize(SaveStream output)
        {
            output.WriteString(this.Name);
            output.WriteValueU32(this.Unknown1);
            output.WriteValueU32(this.Unknown2);
            output.WriteValueU32(this.Unknown3);

            // States
            {
                output.WriteValueS32(this.Unknown4s.Count);
                foreach (Unknown4 unknown3 in this.Unknown4s)
                {
                    unknown3.Serialize(output);
                }
            }
        }
    }
}
