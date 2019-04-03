using System.Collections.Generic;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class EchoPlaythrough
    {
        public uint Playthrough;
        public List<Echo> Echoes = new List<Echo>();

        public void Deserialize(SaveStream input)
        {
            this.Playthrough = input.ReadValueU32();

            // Echos
            {
                uint count = input.ReadValueU32();
                this.Echoes.Clear();
                for (uint i = 0; i < count; i++)
                {
                    Echo echo = new Echo();
                    echo.Deserialize(input);
                    this.Echoes.Add(echo);
                }
            }
        }

        public void Serialize(SaveStream output)
        {
            output.WriteValueU32(this.Playthrough);

            // Echos
            {
                output.WriteValueS32(this.Echoes.Count);
                foreach (Echo echo in this.Echoes)
                {
                    echo.Serialize(output);
                }
            }
        }
    }
}
