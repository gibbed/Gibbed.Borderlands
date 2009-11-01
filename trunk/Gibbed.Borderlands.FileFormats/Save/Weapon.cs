using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class Weapon : ICloneable
    {
        public string Grade { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public string Grip { get; set; }
        public string Magazine { get; set; }
        public string Barrel { get; set; }
        public string Sight { get; set; }
        public string Stock { get; set; }
        public string Action { get; set; }
        public string Accessory { get; set; }
        public string Material { get; set; }
        public string Prefix { get; set; }
        public string Title { get; set; }
        public UInt32 ClipSize { get; set; }
        public UInt32 Quality { get; set; }
        public UInt32 EquipSlot { get; set; }

        public void Deserialize(Stream input)
        {
            this.Grade = input.ReadStringASCIIU32();
            this.Manufacturer = input.ReadStringASCIIU32();
            this.Type = input.ReadStringASCIIU32();
            this.Body = input.ReadStringASCIIU32();
            this.Grip = input.ReadStringASCIIU32();
            this.Magazine = input.ReadStringASCIIU32();
            this.Barrel = input.ReadStringASCIIU32();
            this.Sight = input.ReadStringASCIIU32();
            this.Stock = input.ReadStringASCIIU32();
            this.Action = input.ReadStringASCIIU32();
            this.Accessory = input.ReadStringASCIIU32();
            this.Material = input.ReadStringASCIIU32();
            this.Prefix = input.ReadStringASCIIU32();
            this.Title = input.ReadStringASCIIU32();
            this.ClipSize = input.ReadValueU32();
            this.Quality = input.ReadValueU32();
            this.EquipSlot = input.ReadValueU32();
        }

        public void Serialize(Stream output)
        {
            output.WriteStringASCIIU32(this.Grade);
            output.WriteStringASCIIU32(this.Manufacturer);
            output.WriteStringASCIIU32(this.Type);
            output.WriteStringASCIIU32(this.Body);
            output.WriteStringASCIIU32(this.Grip);
            output.WriteStringASCIIU32(this.Magazine);
            output.WriteStringASCIIU32(this.Barrel);
            output.WriteStringASCIIU32(this.Sight);
            output.WriteStringASCIIU32(this.Stock);
            output.WriteStringASCIIU32(this.Action);
            output.WriteStringASCIIU32(this.Accessory);
            output.WriteStringASCIIU32(this.Material);
            output.WriteStringASCIIU32(this.Prefix);
            output.WriteStringASCIIU32(this.Title);
            output.WriteValueU32(this.ClipSize);
            output.WriteValueU32(this.Quality);
            output.WriteValueU32(this.EquipSlot);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
