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
        public uint ClipSize { get; set; }
        public uint Quality { get; set; }
        public uint EquipSlot { get; set; }

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
