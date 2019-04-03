namespace Gibbed.Borderlands.FileFormats.Save
{
    public class Skill
    {
        public string Name { get; set; }
        public uint Level { get; set; }
        public uint Experience { get; set; }
        public int ArtifactMode { get; set; }

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
