using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class Skill
    {
        public string Name { get; set; }
        public UInt32 Level { get; set; }
        public UInt32 Experience { get; set; }
        public Int32 ArtifactMode { get; set; }

        public void Deserialize(Stream input)
        {
            this.Name = input.ReadStringASCIIU32();
            this.Level = input.ReadValueU32();
            this.Experience = input.ReadValueU32();
            this.ArtifactMode = input.ReadValueS32();
        }

        public void Serialize(Stream output)
        {
            output.WriteStringASCIIU32(this.Name);
            output.WriteValueU32(this.Level);
            output.WriteValueU32(this.Experience);
            output.WriteValueS32(this.ArtifactMode);
        }

        public override string ToString()
        {
            string rez = "";

            rez += "Level " + this.Level.ToString();

            if (this.Experience > 0)
            {
                rez += ", XP " + this.Experience.ToString();
            }

            if (this.ArtifactMode != -1)
            {
                rez += ", " + this.ArtifactMode.ToString("X8");
            }

            return rez;
        }
    }
}
