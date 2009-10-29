using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Gibbed.Borderlands.FileFormats;

namespace Gibbed.Borderlands.SaveEdit
{
    public partial class Editor : Form
    {
        private Player Player
        {
            get
            {
                return (Player)this.playerSource.DataSource;
            }

            set
            {
                this.playerSource.DataSource = value;
            }
        }

        public Editor()
        {
            this.InitializeComponent();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "My Games");
            path = Path.Combine(path, "Borderlands");
            path = Path.Combine(path, "SaveData");

            this.openFileDialog.InitialDirectory = path;
            this.saveFileDialog.InitialDirectory = path;
        }

        private void OnNewBerserker(object sender, EventArgs e)
        {
            this.Player = Player.Default(Character.Berserker);
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream input = this.openFileDialog.OpenFile();
            SaveFile save = new SaveFile();
            save.Deserialize(input);
            input.Close();

            this.Player = save.Player;
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            SaveFile save = new SaveFile();
            save.Player = this.Player;
            save.Serialize(output);
            output.Close();
        }
    }
}
