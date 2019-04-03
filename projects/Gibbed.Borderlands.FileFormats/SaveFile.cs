using System;
using System.IO;
using System.Text;
using Gibbed.IO;

namespace Gibbed.Borderlands.FileFormats
{
    public class SaveFile
    {
        public Endian Endian { get; set; }
        public Save.Player PlayerData { get; set; }
        
        public SaveFile()
        {
            this.PlayerData = new Save.Player();
            this.Endian = Endian.Little;
        }

        public SaveFile(Save.Player playerData)
        {
            this.PlayerData = playerData;
            this.Endian = Endian.Little;
        }
        
        public void Deserialize(Stream input)
        {
            if (input.ReadString(3, Encoding.ASCII) != "WSG") // WSG is probably WillowSaveGame
            {
                throw new FormatException("not a Borderlands save file");
            }

            UInt32 version = input.ReadValueU32();
            if (version != 2 && version.Swap() != 2)
            {
                throw new FormatException("unsupported Borderlands save file version (" + version.ToString() + ")");
            }

            this.Endian = version == 2 ? Endian.Little : Endian.Big;

            SaveStream saveStream = new SaveStream(input, this.Endian);

            this.PlayerData = new Save.Player();
            this.PlayerData.Deserialize(saveStream);
        }

        public void Serialize(Stream output)
        {
            output.WriteString("WSG", Encoding.ASCII);
            output.WriteValueU32(2, this.Endian);

            SaveStream saveStream = new SaveStream(output, this.Endian);

            this.PlayerData.Serialize(saveStream);
        }
    }
}
