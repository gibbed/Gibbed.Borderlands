using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Gibbed.Borderlands.FileFormats;
using Save = Gibbed.Borderlands.FileFormats.Save;

namespace Gibbed.Borderlands.SaveEdit.DefaultPlayer
{
    public static class Brick
    {
        public static Save.Player Create()
        {
            Save.Player player = new Save.Player();

            player.SaveSlot = 1;
            player.PlayTime = 1;
            player.SaveTime = "20091026000000";

            // Version
            player.Version = 35;
            player.ExtraDataVersion = 35;

            // Zone
            player.CurrentStation = "None";

            // Attributes
            player.Level = 1;
            player.Experience = 0;
            player.SkillPoints = 0;
            player.Money = 80;

            player.Character = "gd_Brick.Character.CharacterClass_Brick";

            // Backpack
            player.WeaponSlots = 2;
            player.BackpackSlots = 12;

            // Weapons
            player.Weapons.Add(
                new Save.Weapon()
                {
                    Grade = "gd_itemgrades.StarterGear.ItemGrade_StarterGear",

                    Type = "gd_weap_combat_shotgun.A_Weapon.WeaponType_combat_shotgun",

                    Prefix = "gd_weap_names_shared.Prefix_Starter.Prefix__BrickShotgun_Busted",
                    Title = "gd_weap_combat_shotgun.Title.Title__Shotgun",
                    Manufacturer = "gd_manufacturers.Manufacturers.Vladof",

                    ClipSize = 0,
                    EquipSlot = 1,
                    Quality = 0,

                    Accessory = "None",
                    Action = "None",
                    Barrel = "gd_weap_combat_shotgun.Barrel.barrel2",
                    Body = "gd_weap_combat_shotgun.Body.body1",
                    Grip = "gd_weap_combat_shotgun.Grip.grip3a",
                    Magazine = "gd_weap_combat_shotgun.mag.mag1",
                    Material = "gd_weap_shared_materialparts.ManufacturerMaterials.Material_Vladof_0_starter",
                    Sight = "gd_weap_combat_shotgun.Sight.sightnone",
                    Stock = "gd_weap_combat_shotgun.Stock.stock_none",
                });

            // Ammo
            player.AmmoPools.Add(
                new Save.AmmoPool()
                {
                    Name = "d_resources.AmmoResources.Ammo_Combat_Shotgun",
                    Pool = "d_resourcepools.AmmoPools.Ammo_Combat_Shotgun_Pool",
                    Quantity = 30.0f,
                    UpgradeLevel = 0,
                });

            // New-U
            player.Name = "Brick";
            player.Color1 = 0xFF667391;
            player.Color2 = 0xFF667391;
            player.Color3 = 0xFF6699B3;

            // Missions
            Save.MissionPlaythrough missionZone;

            missionZone = new Save.MissionPlaythrough();
            missionZone.Playthrough = 0;
            missionZone.ActiveMission = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add(
                new Save.Mission()
                {
                    Name = "Z0_Missions.Missions.M_IntroStateSaver",
                    Unknown1 = 2,
                    Unknown2 = 0,
                    Unknown3 = 0,
                });
            player.MissionPlaythroughs.Add(missionZone);

            missionZone = new Save.MissionPlaythrough();
            missionZone.Playthrough = 1;
            missionZone.ActiveMission = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add(
                new Save.Mission()
                {
                    Name = "Z0_Missions.Missions.M_IntroStateSaver",
                    Unknown1 = 2,
                    Unknown2 = 0,
                    Unknown3 = 0,
                });
            player.MissionPlaythroughs.Add(missionZone);

            missionZone = new Save.MissionPlaythrough();
            missionZone.Playthrough = 2;
            missionZone.ActiveMission = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add(
                new Save.Mission()
                {
                    Name = "Z0_Missions.Missions.M_IntroStateSaver",
                    Unknown1 = 2,
                    Unknown2 = 0,
                    Unknown3 = 0,
                });
            player.MissionPlaythroughs.Add(missionZone);


            // Echo Zones
            player.EchoPlaythroughs.Add(
                new Save.EchoPlaythrough()
                {
                    Playthrough = 0,
                });

            // Unknowns
            player.Unknown03 = 0;
            player.MaybePlaythroughUnlocked = 0;
            player.Unknown07 = 0;
            player.Unknown08 = 0;
            player.Unknown09 = 0;
            player.Unknown10 = 0;
            player.Unknown21 = "";
            player.Unknown22 = 26;
            player.Unknown23 = 42915336;
            player.Unknown26 = 1;
            player.Unknown34 = 0;

            return player;
        }
    }
}
