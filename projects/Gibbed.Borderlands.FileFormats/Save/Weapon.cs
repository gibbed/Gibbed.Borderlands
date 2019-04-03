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

        public void Deserialize(SaveStream input)
        {
            this.Grade = input.ReadString();
            this.Manufacturer = input.ReadString();
            this.Type = input.ReadString();
            this.Body = input.ReadString();
            this.Grip = input.ReadString();
            this.Magazine = input.ReadString();
            this.Barrel = input.ReadString();
            this.Sight = input.ReadString();
            this.Stock = input.ReadString();
            this.Action = input.ReadString();
            this.Accessory = input.ReadString();
            this.Material = input.ReadString();
            this.Prefix = input.ReadString();
            this.Title = input.ReadString();
            this.ClipSize = input.ReadValueU32();
            this.Quality = input.ReadValueU32();
            this.EquipSlot = input.ReadValueU32();
        }

        public void Serialize(SaveStream output)
        {
            output.WriteString(this.Grade);
            output.WriteString(this.Manufacturer);
            output.WriteString(this.Type);
            output.WriteString(this.Body);
            output.WriteString(this.Grip);
            output.WriteString(this.Magazine);
            output.WriteString(this.Barrel);
            output.WriteString(this.Sight);
            output.WriteString(this.Stock);
            output.WriteString(this.Action);
            output.WriteString(this.Accessory);
            output.WriteString(this.Material);
            output.WriteString(this.Prefix);
            output.WriteString(this.Title);
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
