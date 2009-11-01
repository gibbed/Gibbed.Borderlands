using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class Item : ICloneable
    {
        public string Grade { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public string LeftSide { get; set; }
        public string RightSide { get; set; }
        public string Material { get; set; }
        public string Manufacturer { get; set; }
        public string Prefix { get; set; }
        public string Title { get; set; }
        public UInt32 Unknown09 { get; set; }
        public UInt32 Quality { get; set; }
        public UInt32 Equipped { get; set; }

        public void Deserialize(Stream input)
        {
            this.Grade = input.ReadStringASCIIU32();
            this.Type = input.ReadStringASCIIU32();
            this.Body = input.ReadStringASCIIU32();
            this.LeftSide = input.ReadStringASCIIU32();
            this.RightSide = input.ReadStringASCIIU32();
            this.Material = input.ReadStringASCIIU32();
            this.Manufacturer = input.ReadStringASCIIU32();
            this.Prefix = input.ReadStringASCIIU32();
            this.Title = input.ReadStringASCIIU32();
            this.Unknown09 = input.ReadValueU32();
            this.Quality = input.ReadValueU32();
            this.Equipped = input.ReadValueU32();
        }

        public void Serialize(Stream output)
        {
            output.WriteStringASCIIU32(this.Grade);
            output.WriteStringASCIIU32(this.Type);
            output.WriteStringASCIIU32(this.Body);
            output.WriteStringASCIIU32(this.LeftSide);
            output.WriteStringASCIIU32(this.RightSide);
            output.WriteStringASCIIU32(this.Material);
            output.WriteStringASCIIU32(this.Manufacturer);
            output.WriteStringASCIIU32(this.Prefix);
            output.WriteStringASCIIU32(this.Title);
            output.WriteValueU32(this.Unknown09);
            output.WriteValueU32(this.Quality);
            output.WriteValueU32(this.Equipped);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
