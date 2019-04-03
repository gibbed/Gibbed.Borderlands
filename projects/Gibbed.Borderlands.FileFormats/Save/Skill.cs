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

        public void Deserialize(SaveStream input)
        {
            this.Name = input.ReadString();
            this.Level = input.ReadValueU32();
            this.Experience = input.ReadValueU32();
            this.ArtifactMode = input.ReadValueS32();
        }

        public void Serialize(SaveStream output)
        {
            output.WriteString(this.Name);
            output.WriteValueU32(this.Level);
            output.WriteValueU32(this.Experience);
            output.WriteValueS32(this.ArtifactMode);
        }
    }
}
