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
        public uint Unknown09 { get; set; }
        public uint Quality { get; set; }
        public uint Equipped { get; set; }

        public void Deserialize(SaveStream input)
        {
            this.Grade = input.ReadString();
            this.Type = input.ReadString();
            this.Body = input.ReadString();
            this.LeftSide = input.ReadString();
            this.RightSide = input.ReadString();
            this.Material = input.ReadString();
            this.Manufacturer = input.ReadString();
            this.Prefix = input.ReadString();
            this.Title = input.ReadString();
            this.Unknown09 = input.ReadValueU32();
            this.Quality = input.ReadValueU32();
            this.Equipped = input.ReadValueU32();
        }

        public void Serialize(SaveStream output)
        {
            output.WriteString(this.Grade);
            output.WriteString(this.Type);
            output.WriteString(this.Body);
            output.WriteString(this.LeftSide);
            output.WriteString(this.RightSide);
            output.WriteString(this.Material);
            output.WriteString(this.Manufacturer);
            output.WriteString(this.Prefix);
            output.WriteString(this.Title);
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
