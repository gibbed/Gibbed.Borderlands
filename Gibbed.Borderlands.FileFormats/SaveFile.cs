using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats
{
    public class SaveFile
    {
        public int Version = 2;
        public Player Player = new Player();
        
        public void Deserialize(Stream input)
        {
            if (input.ReadStringASCII(3) != "WSG") // WSG is probably WillowSaveGame
            {
                throw new FormatException("not a Borderlands save file");
            }

            this.Version = input.ReadValueS32();
            if (this.Version != 2)
            {
                throw new FormatException("unsupported Borderlands save file version (" + this.Version.ToString() + ")");
            }

            if (this.Version == 2)
            {
                this.Player = new Player();
                this.Player.Deserialize(input);
            }
        }

        public void Serialize(Stream output)
        {
            output.WriteStringASCII("WSG");
            output.WriteValueS32(this.Version);
            this.Player.Serialize(output);
        }
    }
}
