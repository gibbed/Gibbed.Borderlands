using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class AmmoPool
    {
        public string Name { get; set; }
        public string Pool { get; set; }
        public float Quantity { get; set; }
        public Int32 UpgradeLevel { get; set; }

        public void Deserialize(Stream input)
        {
            this.Name = input.ReadStringASCIIU32();
            this.Pool = input.ReadStringASCIIU32();
            this.Quantity = input.ReadValueF32();
            this.UpgradeLevel = input.ReadValueS32();
        }

        public void Serialize(Stream output)
        {
            output.WriteStringASCIIU32(this.Name);
            output.WriteStringASCIIU32(this.Pool);
            output.WriteValueF32(this.Quantity);
            output.WriteValueS32(this.UpgradeLevel);
        }
    }
}
