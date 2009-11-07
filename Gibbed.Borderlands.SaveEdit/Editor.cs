using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Gibbed.Borderlands.FileFormats;
using Save = Gibbed.Borderlands.FileFormats.Save;

namespace Gibbed.Borderlands.SaveEdit
{
    public partial class Editor : Form
    {
        private SaveFile Save
        {
            get
            {
                return (SaveFile)this.saveFileSource.DataSource;
            }

            set
            {
                this.saveFileSource.DataSource = value;
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

            this.Save = new SaveFile(DefaultPlayer.Brick.Create());
        }

        private void OnNewBerserker(object sender, EventArgs e)
        {
            this.Save = new SaveFile(DefaultPlayer.Brick.Create());
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SaveFile save = new SaveFile();

            Stream input = this.openFileDialog.OpenFile();
            save.Deserialize(input);
            input.Close();

            this.Save = save;
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            this.Save.Serialize(output);
            output.Close();
        }

        private void OnWeaponDuplicate(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.weaponsDataGrid.SelectedRows)
            {
                Save.Weapon clone = (Save.Weapon)((Save.Weapon)row.DataBoundItem).Clone();
                clone.EquipSlot = 0;
                this.weaponsSource.Add(clone);
            }
        }

        private void OnItemDuplicate(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.itemsDataGrid.SelectedRows)
            {
                Save.Item clone = (Save.Item)((Save.Item)row.DataBoundItem).Clone();
                clone.Equipped = 0;
                this.itemsSource.Add(clone);
            }
        }

        private string GetSkillLevel(string name)
        {
            foreach (Save.Skill skill in this.Save.PlayerData.Skills.Where(candidate => candidate.Name.ToLowerInvariant() == name.ToLowerInvariant()))
            {
                return Math.Max(0, Math.Min(5, skill.Level)).ToString();
            }

            return "0";
        }

        private string GetSkillTreeUrl()
        {
            string url = "http://www.borderlandsthegame.com/skilltree/";

            if (this.Save.PlayerData.Character == "gd_Roland.Character.CharacterClass_Roland")
            {
                url += "roland/#0";

                url += GetSkillLevel("gd_Skills2_Roland.Action.A_DeployScorpio");

                url += GetSkillLevel("gd_Skills2_Roland.Support.Impact");
                url += GetSkillLevel("gd_Skills2_Roland.Infantry.Sentry");
                url += GetSkillLevel("gd_Skills2_Roland.Infantry.Scattershot");
                url += GetSkillLevel("gd_Skills2_Roland.Infantry.MetalStorm");
                url += GetSkillLevel("gd_Skills2_Roland.Infantry.Refire");
                url += GetSkillLevel("gd_Skills2_Roland.Infantry.Assault");
                url += GetSkillLevel("gd_Skills2_Roland.Infantry.GuidedMissile");

                url += GetSkillLevel("gd_Skills2_Roland.Support.Defense");
                url += GetSkillLevel("gd_Skills2_Roland.Support.Stockpile");
                url += GetSkillLevel("gd_Skills2_Roland.Support.QuickCharge");
                url += GetSkillLevel("gd_Skills2_Roland.Support.Barrage");
                url += GetSkillLevel("gd_Skills2_Roland.Support.Grenadier");
                url += GetSkillLevel("gd_Skills2_Roland.Support.deploy");
                url += GetSkillLevel("gd_Skills2_Roland.Support.SupplyDrop");

                url += GetSkillLevel("gd_Skills2_Roland.Medic.Fitness");
                url += GetSkillLevel("gd_Skills2_Roland.Medic.AidStation");
                url += GetSkillLevel("gd_Skills2_Roland.Medic.Overload");
                url += GetSkillLevel("gd_Skills2_Roland.Medic.Cauterize");
                url += GetSkillLevel("gd_Skills2_Roland.Medic.Revive");
                url += GetSkillLevel("gd_Skills2_Roland.Medic.Grit");
                url += GetSkillLevel("gd_Skills2_Roland.Medic.Stat");
            }
            else if (this.Save.PlayerData.Character == "gd_mordecai.Character.CharacterClass_Mordecai")
            {
                url += "mordecai/#1";

                url += GetSkillLevel("gd_Skills2_Mordecai.Action.A_LaunchBloodwing");

                url += GetSkillLevel("gd_Skills2_Mordecai.Sniper.Focus");
                url += GetSkillLevel("gd_Skills2_Mordecai.Sniper.Caliber");
                url += GetSkillLevel("gd_Skills2_Mordecai.Sniper.Smirk");
                url += GetSkillLevel("gd_Skills2_Mordecai.Sniper.Killer");
                url += GetSkillLevel("gd_Skills2_Mordecai.Sniper.Loaded");
                url += GetSkillLevel("gd_Skills2_Mordecai.Sniper.CarrionCall");
                url += GetSkillLevel("gd_Skills2_Mordecai.Sniper.Trespass");

                url += GetSkillLevel("gd_Skills2_Mordecai.Rogue.SwiftStrike");
                url += GetSkillLevel("gd_Skills2_Mordecai.Rogue.Swipe");
                url += GetSkillLevel("gd_Skills2_Mordecai.Rogue.FastHands");
                url += GetSkillLevel("gd_Skills2_Mordecai.Rogue.OutForBlood");
                url += GetSkillLevel("gd_Skills2_Mordecai.Rogue.AerialImpact");
                url += GetSkillLevel("gd_Skills2_Mordecai.Rogue.Ransack");
                url += GetSkillLevel("gd_Skills2_Mordecai.Rogue.BirdOfPrey");

                url += GetSkillLevel("gd_Skills2_Mordecai.Gunslinger.Deadly");
                url += GetSkillLevel("gd_Skills2_Mordecai.Gunslinger.GunCrazy");
                url += GetSkillLevel("gd_Skills2_Mordecai.Gunslinger.LethalStrike");
                url += GetSkillLevel("gd_Skills2_Mordecai.Gunslinger.RiotousRemedy");
                url += GetSkillLevel("gd_Skills2_Mordecai.Gunslinger.Predator");
                url += GetSkillLevel("gd_Skills2_Mordecai.Gunslinger.HairTrigger");
                url += GetSkillLevel("gd_Skills2_Mordecai.Gunslinger.Relentless");
            }
            else if (this.Save.PlayerData.Character == "gd_lilith.Character.CharacterClass_Lilith")
            {
                url += "lilith/#2";

                url += GetSkillLevel("gd_Skills2_Lilith.Action.A_PhaseWalk");

                url += GetSkillLevel("gd_Skills2_Lilith.Controller.Diva");
                url += GetSkillLevel("gd_Skills2_Lilith.Controller.Striking");
                url += GetSkillLevel("gd_Skills2_Lilith.Controller.InnerGlow");
                url += GetSkillLevel("gd_Skills2_Lilith.Controller.DramaticEntrance");
                url += GetSkillLevel("gd_Skills2_Lilith.Controller.HardToGet");
                url += GetSkillLevel("gd_Skills2_Lilith.Controller.GirlPower");
                url += GetSkillLevel("gd_Skills2_Lilith.Controller.MindGames");

                url += GetSkillLevel("gd_Skills2_Lilith.Elemental.Quicksilver");
                url += GetSkillLevel("gd_Skills2_Lilith.Elemental.Spark");
                url += GetSkillLevel("gd_Skills2_Lilith.Elemental.Resilience");
                url += GetSkillLevel("gd_Skills2_Lilith.Elemental.Radiance");
                url += GetSkillLevel("gd_Skills2_Lilith.Elemental.Venom");
                url += GetSkillLevel("gd_Skills2_Lilith.Elemental.Intuition");
                url += GetSkillLevel("gd_Skills2_Lilith.Elemental.Phoenix");

                url += GetSkillLevel("gd_Skills2_Lilith.Assassin.Slayer");
                url += GetSkillLevel("gd_Skills2_Lilith.Assassin.SilentResolve");
                url += GetSkillLevel("gd_Skills2_Lilith.Assassin.Enforcer");
                url += GetSkillLevel("gd_Skills2_Lilith.Assassin.HitAndRun");
                url += GetSkillLevel("gd_Skills2_Lilith.Assassin.HighVelocity");
                url += GetSkillLevel("gd_Skills2_Lilith.Assassin.Blackout");
                url += GetSkillLevel("gd_Skills2_Lilith.Assassin.PhaseStrike");
            }
            else if (this.Save.PlayerData.Character == "gd_Brick.Character.CharacterClass_Brick")
            {
                url += "brick/#3";

                url += GetSkillLevel("gd_Skills2_Brick.Action.A_Berserk");

                url += GetSkillLevel("gd_Skills2_Brick.Brawler.IronFist");
                url += GetSkillLevel("gd_Skills2_Brick.Brawler.EndlessRage");
                url += GetSkillLevel("gd_Skills2_Brick.Brawler.StingLikeaBee");
                url += GetSkillLevel("gd_Skills2_Brick.Brawler.HeavyHanded");
                url += GetSkillLevel("gd_Skills2_Brick.Brawler.PrizeFighter");
                url += GetSkillLevel("gd_Skills2_Brick.Brawler.ShortFuse");
                url += GetSkillLevel("gd_Skills2_Brick.Brawler.BloodSport");

                url += GetSkillLevel("gd_Skills2_Brick.Tank.Hardened");
                url += GetSkillLevel("gd_Skills2_Brick.Tank.Safeguard");
                url += GetSkillLevel("gd_Skills2_Brick.Tank.Bash");
                url += GetSkillLevel("gd_Skills2_Brick.Tank.Juggernaut");
                url += GetSkillLevel("gd_Skills2_Brick.Tank.PayBack");
                url += GetSkillLevel("gd_Skills2_Brick.Tank.Diehard");
                url += GetSkillLevel("gd_Skills2_Brick.Tank.Unbreakable");

                url += GetSkillLevel("gd_Skills2_Brick.Tank.Endowed");
                url += GetSkillLevel("gd_Skills2_Brick.Blaster.RapidReload");
                url += GetSkillLevel("gd_Skills2_Brick.Blaster.Revenge");
                url += GetSkillLevel("gd_Skills2_Brick.Blaster.WideLoad");
                url += GetSkillLevel("gd_Skills2_Brick.Blaster.Liquidate");
                url += GetSkillLevel("gd_Skills2_Brick.Blaster.CastIron");
                url += GetSkillLevel("gd_Skills2_Brick.Blaster.MasterBlaster");
            }

            return url;
        }

        private void OnSkillExportClipboard(object sender, EventArgs e)
        {
            Clipboard.SetText(this.GetSkillTreeUrl());
        }

        private void OnSkillExportBrowser(object sender, EventArgs e)
        {
            Process.Start(this.GetSkillTreeUrl());
        }
    }
}
