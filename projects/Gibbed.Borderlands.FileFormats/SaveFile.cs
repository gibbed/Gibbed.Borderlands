using System;
using System.Globalization;
using System.IO;
using System.Text;
using Gibbed.Borderlands.FileFormats.Save;
using Gibbed.IO;

namespace Gibbed.Borderlands.FileFormats
{
    public class SaveFile
    {
        public const string Signature = "WSG"; // Probably "WillowSaveGame"

        #region Fields
        private Endian _Endian;
        private Player _PlayerData;
        #endregion

        public SaveFile()
        {
            this._Endian = Endian.Little;
            this._PlayerData = new Player();
        }

        public SaveFile(Player playerData)
        {
            this._Endian = Endian.Little;
            this._PlayerData = playerData;
        }

        #region Properties
        public Endian Endian
        {
            get { return this._Endian; }
            set { this._Endian = value; }
        }

        public Player PlayerData
        {
            get { return this._PlayerData; }
            set { this._PlayerData = value; }
        }

        // So I don't have to rework the SaveEdit UI.
        public bool LittleEndian
        {
            get { return this.Endian == Endian.Little; }
            set { this.Endian = value == true ? Endian.Little : Endian.Big; }
        }
        #endregion

        public void Serialize(Stream output)
        {
            output.WriteString(Signature, Encoding.ASCII);
            output.WriteValueU32(2, this.Endian);

            SaveStream saveStream = new SaveStream(output, this.Endian);

            this.PlayerData.Serialize(saveStream);
        }

        public void Deserialize(Stream input)
        {
            if (input.ReadString(Signature.Length, Encoding.ASCII) != Signature)
            {
                throw new FormatException("not a save");
            }

            var version = input.ReadValueU32();
            if (version != 2 && version.Swap() != 2)
            {
                throw new FormatException("unsupported save version " + version.ToString(CultureInfo.InvariantCulture));
            }
            var endian = version == 2 ? Endian.Little : Endian.Big;

            var saveStream = new SaveStream(input, endian);

            var playerData = new Player();
            playerData.Deserialize(saveStream);

            this._Endian = endian;
            this._PlayerData = playerData;
        }
    }
}
