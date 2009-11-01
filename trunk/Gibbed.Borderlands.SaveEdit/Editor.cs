using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Gibbed.Borderlands.FileFormats;
using Save = Gibbed.Borderlands.FileFormats.Save;

namespace Gibbed.Borderlands.SaveEdit
{
    public partial class Editor : Form
    {
        private Save.Player ActivePlayer
        {
            get
            {
                return (Save.Player)this.playerSource.DataSource;
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
            classes.Add(new PlayerClass("gd_Roland.Character.CharacterClass_Roland", "Roland"));

            this.characterComboBox.ValueMember = "Type";
            this.characterComboBox.DisplayMember = "Name";
            this.characterComboBox.DataSource = classes;

            this.ActivePlayer = DefaultPlayer.Brick.Create();
        }

        private void OnNewBerserker(object sender, EventArgs e)
        {
            this.ActivePlayer = DefaultPlayer.Brick.Create();
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

            this.ActivePlayer = save.PlayerData;
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            SaveFile save = new SaveFile();
            save.PlayerData = this.ActivePlayer;
            save.Serialize(output);
            output.Close();
        }

        private void OnWeaponDuplicate(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.weaponsDataGrid.SelectedRows)
            {
                Save.Weapon clone = (Save.Weapon)((Save.Weapon)row.DataBoundItem).Clone();
                clone.EquipSlot = 0;
                this.weaponsBindingSource.Add(clone);
            }
        }

        private void OnItemDuplicate(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.itemsDataGrid.SelectedRows)
            {
                Save.Item clone = (Save.Item)((Save.Item)row.DataBoundItem).Clone();
                clone.Equipped = 0;
                this.itemsBindingSource.Add(clone);
            }
        }
    }
}
