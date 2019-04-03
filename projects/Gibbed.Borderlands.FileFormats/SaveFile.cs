using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats
{
    public class SaveFile
    {
        public bool LittleEndian { get; set; }
        public Save.Player PlayerData { get; set; }
        
        public SaveFile()
        {
            this.PlayerData = new Save.Player();
            this.LittleEndian = true;
        }

        public SaveFile(Save.Player playerData)
        {
            this.PlayerData = playerData;
            this.LittleEndian = true;
        }
        
        public void Deserialize(Stream input)
        {
            if (input.ReadStringASCII(3) != "WSG") // WSG is probably WillowSaveGame
            {
                throw new FormatException("not a Borderlands save file");
            }

            UInt32 version = input.ReadValueU32();
            if (version != 2 && version.Swap() != 2)
            {
                throw new FormatException("unsupported Borderlands save file version (" + version.ToString() + ")");
            }

            this.LittleEndian = version == 2;

            SaveStream saveStream = new SaveStream(input, this.LittleEndian);

            this.PlayerData = new Save.Player();
            this.PlayerData.Deserialize(saveStream);
        }

        public void Serialize(Stream output)
        {
            output.WriteStringASCII("WSG");
            output.WriteValueU32(2, this.LittleEndian);

            SaveStream saveStream = new SaveStream(output, this.LittleEndian);

            this.PlayerData.Serialize(saveStream);
        }
    }
}
