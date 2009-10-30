using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Gibbed.Borderlands.FileFormats;

namespace Gibbed.Borderlands.SaveEdit
{
    public partial class Editor : Form
    {
        private Player ActivePlayer
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

            List<PlayerClass> classes = new List<PlayerClass>();
            classes.Add(new PlayerClass("gd_Brick.Character.CharacterClass_Brick", "Brick"));
            classes.Add(new PlayerClass("gd_lilith.Character.CharacterClass_Lilith", "Lilith"));
            classes.Add(new PlayerClass("gd_mordecai.Character.CharacterClass_Mordecai", "Mordecai"));
            classes.Add(new PlayerClass("gd_Roland.Character.CharacterClass_Mordecai", "Roland"));

            this.characterComboBox.ValueMember = "Type";
            this.characterComboBox.DisplayMember = "Name";
            this.characterComboBox.DataSource = classes;

            this.ActivePlayer = Player.Default(CharacterType.Berserker);
        }

        private void OnNewBerserker(object sender, EventArgs e)
        {
            this.ActivePlayer = Player.Default(CharacterType.Berserker);
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

            this.ActivePlayer = save.Player;
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            SaveFile save = new SaveFile();
            save.Player = this.ActivePlayer;
            save.Serialize(output);
            output.Close();
        }
    }
}
