namespace Gibbed.Borderlands.FileFormats.Save
{
    public class AmmoPool
    {
        public string Name { get; set; }
        public string Pool { get; set; }
        public float Quantity { get; set; }
        public int UpgradeLevel { get; set; }

        public void Deserialize(SaveStream input)
        {
            this.Name = input.ReadString();
            this.Pool = input.ReadString();
            this.Quantity = input.ReadValueF32();
            this.UpgradeLevel = input.ReadValueS32();
        }

        public void Serialize(SaveStream output)
        {
            output.WriteString(this.Name);
            output.WriteString(this.Pool);
            output.WriteValueF32(this.Quantity);
            output.WriteValueS32(this.UpgradeLevel);
        }
    }
}
