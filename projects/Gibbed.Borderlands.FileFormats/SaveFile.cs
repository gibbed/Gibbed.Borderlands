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
