using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats
{
    public class Player
    {
        public class Skill
        {
            public string Name { get; set; }
            public UInt32 Level { get; set; }
            public UInt32 Experience { get; set; }
            public Int32 ArtifactMode { get; set; }

            public void Deserialize(Stream input)
            {
                this.Name = input.ReadStringASCIIU32();
                this.Level = input.ReadValueU32();
                this.Experience = input.ReadValueU32();
                this.ArtifactMode = input.ReadValueS32();
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Name);
                output.WriteValueU32(this.Level);
                output.WriteValueU32(this.Experience);
                output.WriteValueS32(this.ArtifactMode);
            }

            public override string ToString()
            {
                string rez = "";

                rez += "Level " + this.Level.ToString();

                if (this.Experience > 0)
                {
                    rez += ", XP " + this.Experience.ToString();
                }

                if (this.ArtifactMode != 0xFFFFFFFF)
                {
                    rez += ", " + this.ArtifactMode.ToString("X8");
                }

                return rez;
            }
        }

        public class AmmoPool
        {
            public string Name { get; set; }
            public string Pool { get; set; }
            public float Quantity { get; set; }
            public Int32 UpgradeLevel { get; set; }

            public void Deserialize(Stream input)
            {
                this.Name = input.ReadStringASCIIU32();
                this.Pool = input.ReadStringASCIIU32();
                this.Quantity = input.ReadValueF32();
                this.UpgradeLevel = input.ReadValueS32();
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Name);
                output.WriteStringASCIIU32(this.Pool);
                output.WriteValueF32(this.Quantity);
                output.WriteValueS32(this.UpgradeLevel);
            }
        }

        public class Item
        {
            public string Grade { get; set; }
            public string Type { get; set; }
            public string Body { get; set; }
            public string LeftSide { get; set; }
            public string RightSide { get; set; }
            public string Material { get; set; }
            public string Manufacturer { get; set; }
            public string Prefix { get; set; }
            public string Title { get; set; }
            public UInt32 Unknown09 { get; set; }
            public UInt32 IsEquipped { get; set; }
            public UInt32 EquipSlot { get; set; }

            public void Deserialize(Stream input)
            {
                this.Grade = input.ReadStringASCIIU32();
                this.Type = input.ReadStringASCIIU32();
                this.Body = input.ReadStringASCIIU32();
                this.LeftSide = input.ReadStringASCIIU32();
                this.RightSide = input.ReadStringASCIIU32();
                this.Material = input.ReadStringASCIIU32();
                this.Manufacturer = input.ReadStringASCIIU32();
                this.Prefix = input.ReadStringASCIIU32();
                this.Title = input.ReadStringASCIIU32();
                this.Unknown09 = input.ReadValueU32();
                this.IsEquipped = input.ReadValueU32();
                this.EquipSlot = input.ReadValueU32();
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Grade);
                output.WriteStringASCIIU32(this.Type);
                output.WriteStringASCIIU32(this.Body);
                output.WriteStringASCIIU32(this.LeftSide);
                output.WriteStringASCIIU32(this.RightSide);
                output.WriteStringASCIIU32(this.Material);
                output.WriteStringASCIIU32(this.Manufacturer);
                output.WriteStringASCIIU32(this.Prefix);
                output.WriteStringASCIIU32(this.Title);
                output.WriteValueU32(this.Unknown09);
                output.WriteValueU32(this.IsEquipped);
                output.WriteValueU32(this.EquipSlot);
            }
        }

        public class Weapon
        {
            public string Grade { get; set; }
            public string Manufacturer { get; set; }
            public string Type { get; set; }
            public string Body { get; set; }
            public string Grip { get; set; }
            public string Magazine { get; set; }
            public string Barrel { get; set; }
            public string Sight { get; set; }
            public string Stock { get; set; }
            public string Action { get; set; }
            public string Accuracy { get; set; }
            public string Material { get; set; }
            public string Prefix { get; set; }
            public string Title { get; set; }
            public UInt32 ClipSize { get; set; }
            public UInt32 IsEquipped { get; set; }
            public UInt32 EquipSlot { get; set; }

            public void Deserialize(Stream input)
            {
                this.Grade = input.ReadStringASCIIU32();
                this.Manufacturer = input.ReadStringASCIIU32();
                this.Type = input.ReadStringASCIIU32();
                this.Body = input.ReadStringASCIIU32();
                this.Grip = input.ReadStringASCIIU32();
                this.Magazine = input.ReadStringASCIIU32();
                this.Barrel = input.ReadStringASCIIU32();
                this.Sight = input.ReadStringASCIIU32();
                this.Stock = input.ReadStringASCIIU32();
                this.Action = input.ReadStringASCIIU32();
                this.Accuracy = input.ReadStringASCIIU32();
                this.Material = input.ReadStringASCIIU32();
                this.Prefix = input.ReadStringASCIIU32();
                this.Title = input.ReadStringASCIIU32();
                this.ClipSize = input.ReadValueU32();
                this.IsEquipped = input.ReadValueU32();
                this.EquipSlot = input.ReadValueU32();
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Grade);
                output.WriteStringASCIIU32(this.Manufacturer);
                output.WriteStringASCIIU32(this.Type);
                output.WriteStringASCIIU32(this.Body);
                output.WriteStringASCIIU32(this.Grip);
                output.WriteStringASCIIU32(this.Magazine);
                output.WriteStringASCIIU32(this.Barrel);
                output.WriteStringASCIIU32(this.Sight);
                output.WriteStringASCIIU32(this.Stock);
                output.WriteStringASCIIU32(this.Action);
                output.WriteStringASCIIU32(this.Accuracy);
                output.WriteStringASCIIU32(this.Material);
                output.WriteStringASCIIU32(this.Prefix);
                output.WriteStringASCIIU32(this.Title);
                output.WriteValueU32(this.ClipSize);
                output.WriteValueU32(this.IsEquipped);
                output.WriteValueU32(this.EquipSlot);
            }
        }

        public class Mission
        {
            public class Unknown4
            {
                public string Unknown0;
                public UInt32 Unknown1;

                public void Deserialize(Stream input)
                {
                    this.Unknown0 = input.ReadStringASCIIU32();
                    this.Unknown1 = input.ReadValueU32();
                }

                public void Serialize(Stream output)
                {
                    output.WriteStringASCIIU32(this.Unknown0);
                    output.WriteValueU32(this.Unknown1);
                }
            }

            public string Name;
            public UInt32 Unknown1;
            public UInt32 Unknown2;
            public UInt32 Unknown3;
            public List<Unknown4> Unknown4s = new List<Unknown4>();

            public void Deserialize(Stream input)
            {
                this.Name = input.ReadStringASCIIU32();
                this.Unknown1 = input.ReadValueU32();
                this.Unknown2 = input.ReadValueU32();
                this.Unknown3 = input.ReadValueU32();

                // States
                {
                    uint count = input.ReadValueU32();
                    this.Unknown4s.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        Unknown4 unknown3 = new Unknown4();
                        unknown3.Deserialize(input);
                        this.Unknown4s.Add(unknown3);
                    }
                }
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Name);
                output.WriteValueU32(this.Unknown1);
                output.WriteValueU32(this.Unknown2);
                output.WriteValueU32(this.Unknown3);

                // States
                {
                    output.WriteValueS32(this.Unknown4s.Count);
                    foreach (Unknown4 unknown3 in this.Unknown4s)
                    {
                        unknown3.Serialize(output);
                    }
                }
            }
        }

        public class MissionZone
        {
            public UInt32 Unknown0;
            public string Name;
            public List<Mission> Missions = new List<Mission>();

            public void Deserialize(Stream input)
            {
                this.Unknown0 = input.ReadValueU32();
                this.Name = input.ReadStringASCIIU32();

                // Missions
                {
                    uint count = input.ReadValueU32();
                    this.Missions.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        Mission mission = new Mission();
                        mission.Deserialize(input);
                        this.Missions.Add( mission);
                    }
                }
            }

            public void Serialize(Stream output)
            {
                output.WriteValueU32(this.Unknown0);
                output.WriteStringASCIIU32(this.Name);

                // Missions
                {
                    output.WriteValueS32(this.Missions.Count);
                    foreach (Mission mission in this.Missions)
                    {
                        mission.Serialize(output);
                    }
                }
            }
        }

        public class Echo
        {
            public string Name;
            public UInt32 Unknown1;
            public UInt32 Unknown2;

            public void Deserialize(Stream input)
            {
                this.Name = input.ReadStringASCIIU32();
                this.Unknown1 = input.ReadValueU32();
                this.Unknown2 = input.ReadValueU32();
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Name);
                output.WriteValueU32(this.Unknown1);
                output.WriteValueU32(this.Unknown2);
            }
        }

        public class EchoZone
        {
            public UInt32 Unknown0;
            public List<Echo> Echoes = new List<Echo>();

            public void Deserialize(Stream input)
            {
                this.Unknown0 = input.ReadValueU32();

                // Echos
                {
                    uint count = input.ReadValueU32();
                    this.Echoes.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        Echo echo = new Echo();
                        echo.Deserialize(input);
                        this.Echoes.Add(echo);
                    }
                }
            }

            public void Serialize(Stream output)
            {
                output.WriteValueU32(this.Unknown0);

                // Echos
                {
                    output.WriteValueS32(this.Echoes.Count);
                    foreach (Echo echo in this.Echoes)
                    {
                        echo.Serialize(output);
                    }
                }
            }
        }

        public UInt32 Version;
        public string ClassType;

        public string ClassName
        {
            get
            {
                if (this.ClassType == "gd_Brick.Character.CharacterClass_Brick")
                {
                    return "Berserker";
                }
                else if (this.ClassType == "gd_lilith.Character.CharacterClass_Lilith")
                {
                    return "Siren";
                }
                else if (this.ClassType == "gd_mordecai.Character.CharacterClass_Mordecai")
                {
                    return "Hunter";
                }

                return this.ClassType;
            }

            set
            {
                if (value == "Berserker")
                {
                    this.ClassType = "gd_Brick.Character.CharacterClass_Brick";
                }
                else if (value == "Siren")
                {
                    this.ClassType = "gd_lilith.Character.CharacterClass_Lilith";
                }
                else if (value == "Hunter")
                {
                    this.ClassType = "gd_mordecai.Character.CharacterClass_Mordecai";
                }
                else
                {
                    this.ClassType = value;
                }
            }
        }

        public UInt32 Level { get; set; }
        public UInt32 Experience { get; set; }
        public UInt32 Unknown02;
        public UInt32 Unknown03;
        public UInt32 Money { get; set; }
        public UInt32 Unknown05;
        public List<Skill> Skills { get; set; }
        public UInt32 Unknown07;
        public UInt32 Unknown08;
        public UInt32 Unknown09;
        public UInt32 Unknown10;
        public List<AmmoPool> AmmoPools { get; set; }
        public List<Item> Items { get; set; }
        public UInt32 BackpackSize { get; set; }
        public UInt32 BackpackCount;
        public List<Weapon> Weapons { get; set; }
        public byte[] Unknown16 = new byte[0];
        public List<string> VisitedStations = new List<string>();
        public string CurrentZone;
        //public ??? Unknown19 = ...
        //public ??? Unknown20 = ...
        public string Unknown21;
        public UInt32 Unknown22;
        public UInt32 Unknown23;
        public UInt32 Unknown24;
        public UInt32 ExtraDataVersion;
        public UInt32 Unknown26;
        public List<MissionZone> MissionZones = new List<MissionZone>();
        public UInt32 Unknown28;
        public string SaveTime;
        public string Name { get; set; }
        public UInt32 Color1;
        public UInt32 Color2;
        public UInt32 Color3;
        public UInt32 Unknown34;
        public List<UInt32> Unknown35 = new List<UInt32>();
        public List<UInt32> Unknown36 = new List<UInt32>();
        public List<EchoZone> EchoZones = new List<EchoZone>();
        public byte[] Unknown38 = new byte[0];

        #region Colors
        public string _Color1
        {
            get
            {
                return this.Color1.ToString("X8");
            }

            set
            {
                this.Color1 = UInt32.Parse(value, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
        }

        public String _Color2
        {
            get
            {
                return this.Color2.ToString("X8");
            }

            set
            {
                this.Color2 = UInt32.Parse(value, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
        }

        public String _Color3
        {
            get
            {
                return this.Color3.ToString("X8");
            }

            set
            {
                this.Color3 = UInt32.Parse(value, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
        }
        #endregion

        public Player()
        {
            this.AmmoPools = new List<AmmoPool>();
            this.Items = new List<Item>();
            this.Weapons = new List<Weapon>();
            this.Skills = new List<Skill>();
        }

        public void Deserialize(Stream input)
        {
            if (input.ReadStringASCII(4) != "PLYR")
            {
                throw new FormatException("not player data");
            }

            this.Version = input.ReadValueU32();
            if (this.Version != 35)
            {
                throw new FormatException("unsupported player data version (" + this.Version.ToString() + ")");
            }

            this.ClassType = input.ReadStringASCIIU32();
            this.Level = input.ReadValueU32();
            this.Experience = input.ReadValueU32();
            this.Unknown02 = input.ReadValueU32();
            this.Unknown03 = input.ReadValueU32();
            this.Money = input.ReadValueU32();
            this.Unknown05 = input.ReadValueU32();

            // Skills
            {
                uint count = input.ReadValueU32();
                this.Skills.Clear();
                for (uint i = 0; i < count; i++)
                {
                    Skill skill = new Skill();
                    skill.Deserialize(input);
                    this.Skills.Add(skill);
                }
            }

            this.Unknown07 = input.ReadValueU32();
            this.Unknown08 = input.ReadValueU32();
            this.Unknown09 = input.ReadValueU32();
            this.Unknown10 = input.ReadValueU32();

            // Ammo Pools
            {
                uint count = input.ReadValueU32();
                this.AmmoPools.Clear();
                for (uint i = 0; i < count; i++)
                {
                    AmmoPool pool = new AmmoPool();
                    pool.Deserialize(input);
                    this.AmmoPools.Add(pool);
                }
            }

            // Items
            {
                uint count = input.ReadValueU32();
                this.Items.Clear();
                for (uint i = 0; i < count; i++)
                {
                    Item item = new Item();
                    item.Deserialize(input);
                    this.Items.Add(item);
                }
            }

            this.BackpackSize = input.ReadValueU32();
            this.BackpackCount = input.ReadValueU32();

            // Weapons
            {
                uint count = input.ReadValueU32();
                this.Weapons.Clear();
                for (uint i = 0; i < count; i++)
                {
                    Weapon weapon = new Weapon();
                    weapon.Deserialize(input);
                    this.Weapons.Add(weapon);
                }
            }

            // Unknown16
            {
                int size = input.ReadValueS32();
                this.Unknown16 = new byte[size];
                input.Read(this.Unknown16, 0, size);
            }

            // Visited Zones
            {
                uint count = input.ReadValueU32();
                this.VisitedStations.Clear();
                for (uint i = 0; i < count; i++)
                {
                    this.VisitedStations.Add(input.ReadStringASCIIU32());
                }
            }

            this.CurrentZone = input.ReadStringASCIIU32();

            // Unknown19
            {
                uint count = input.ReadValueU32();
                if (count != 0)
                {
                    throw new Exception();
                }
            }

            // Unknown20
            {
                uint count = input.ReadValueU32();
                if (count != 0)
                {
                    throw new Exception();
                }
            }

            this.Unknown21 = input.ReadStringASCIIU32(); ;
            this.Unknown22 = input.ReadValueU32();
            this.Unknown23 = input.ReadValueU32();
            this.Unknown24 = input.ReadValueU32();
            this.ExtraDataVersion = input.ReadValueU32();

            if (this.ExtraDataVersion >= 27)
            {
                this.Unknown26 = input.ReadValueU32();
            }

            if (this.ExtraDataVersion >= 28 && this.ExtraDataVersion <= 31)
            {
                // junk
                input.ReadStringASCIIU32();

                {
                    uint count = input.ReadValueU32();
                    for (uint i = 0; i < count; i++)
                    {
                        input.ReadStringASCIIU32();
                    }
                }
            }

            if (this.ExtraDataVersion >= 29)
            {
                // Mission Zones
                {
                    uint count = input.ReadValueU32();
                    this.MissionZones.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        MissionZone missionZone = new MissionZone();
                        missionZone.Deserialize(input);
                        this.MissionZones.Add(missionZone);
                    }
                }
            }

            if (this.ExtraDataVersion >= 30)
            {
                this.Unknown28 = input.ReadValueU32();
                this.SaveTime = input.ReadStringASCIIU32();
            }

            if (this.ExtraDataVersion >= 31)
            {
                this.Name = input.ReadStringASCIIU32();
                this.Color1 = input.ReadValueU32();
                this.Color2 = input.ReadValueU32();
                this.Color3 = input.ReadValueU32();
            }

            if (this.ExtraDataVersion >= 32)
            {
                this.Unknown34 = input.ReadValueU32();

                // Unknown35
                {
                    uint count = input.ReadValueU32();
                    this.Unknown35.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        this.Unknown35.Add(input.ReadValueU32());
                    }
                }
            }

            if (this.ExtraDataVersion >= 33)
            {
                // Unknown36
                {
                    uint count = input.ReadValueU32();
                    this.Unknown36.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        this.Unknown36.Add(input.ReadValueU32());
                    }
                }
            }

            if (this.ExtraDataVersion >= 34)
            {
                // Echo Zones
                {
                    uint count = input.ReadValueU32();
                    this.EchoZones.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        EchoZone echoZone = new EchoZone();
                        echoZone.Deserialize(input);
                        this.EchoZones.Add(echoZone);
                    }
                }
            }

            if (this.ExtraDataVersion >= 35)
            {
                // Unknown38
                {
                    int size = input.ReadValueS32();
                    this.Unknown38 = new byte[size];
                    input.Read(this.Unknown38, 0, size);
                }
            }
        }

        public void Serialize(Stream output)
        {
            output.WriteStringASCII("PLYR");
            output.WriteValueU32(this.Version);
            output.WriteStringASCIIU32(this.ClassType);
            output.WriteValueU32(this.Level);
            output.WriteValueU32(this.Experience);
            output.WriteValueU32(this.Unknown02);
            output.WriteValueU32(this.Unknown03);
            output.WriteValueU32(this.Money);
            output.WriteValueU32(this.Unknown05);

            // Skills
            {
                output.WriteValueS32(this.Skills.Count);
                foreach (Skill skill in this.Skills)
                {
                    skill.Serialize(output);
                }
            }

            output.WriteValueU32(this.Unknown07);
            output.WriteValueU32(this.Unknown08);
            output.WriteValueU32(this.Unknown09);
            output.WriteValueU32(this.Unknown10);

            // Ammo Pools
            {
                output.WriteValueS32(this.AmmoPools.Count);
                foreach (AmmoPool pool in this.AmmoPools)
                {
                    pool.Serialize(output);
                }
            }

            // Items
            {
                output.WriteValueS32(this.Items.Count);
                foreach (Item item in this.Items)
                {
                    item.Serialize(output);
                }
            }

            output.WriteValueU32(this.BackpackSize);
            output.WriteValueU32(this.BackpackCount);

            // Weapons
            {
                output.WriteValueS32(this.Weapons.Count);
                foreach (Weapon weapon in this.Weapons)
                {
                    weapon.Serialize(output);
                }
            }

            // Unknown16
            {
                output.WriteValueS32(this.Unknown16.Length);
                output.Write(this.Unknown16, 0, this.Unknown16.Length);
            }

            // Visited Zones
            {
                output.WriteValueS32(this.VisitedStations.Count);
                foreach (string visitedZone in this.VisitedStations)
                {
                    output.WriteStringASCIIU32(visitedZone);
                }
            }

            output.WriteStringASCIIU32(this.CurrentZone);

            // Unknown19
            {
                // FIXME
                output.WriteValueS32(0);
            }

            // Unknown20
            {
                // FIXME
                output.WriteValueS32(0);
            }

            output.WriteStringASCIIU32(this.Unknown21);
            output.WriteValueU32(this.Unknown22);
            output.WriteValueU32(this.Unknown23);
            output.WriteValueU32(this.Unknown24);
            output.WriteValueU32(this.ExtraDataVersion);

            if (this.ExtraDataVersion >= 27)
            {
                output.WriteValueU32(this.Unknown26);
            }

            if (this.ExtraDataVersion >= 28 && this.ExtraDataVersion <= 31)
            {
                // junk
                output.WriteStringASCIIU32("");
                output.WriteValueU32(0);
            }

            if (this.ExtraDataVersion >= 29)
            {
                // Mission Zones
                {
                    output.WriteValueS32(this.MissionZones.Count);
                    foreach (MissionZone missionZone in this.MissionZones)
                    {
                        missionZone.Serialize(output);
                    }
                }
            }

            if (this.ExtraDataVersion >= 30)
            {
                output.WriteValueU32(this.Unknown28);
                output.WriteStringASCIIU32(this.SaveTime);
            }

            if (this.ExtraDataVersion >= 31)
            {
                output.WriteStringASCIIU32(this.Name);
                output.WriteValueU32(this.Color1);
                output.WriteValueU32(this.Color2);
                output.WriteValueU32(this.Color3);
            }

            if (this.ExtraDataVersion >= 32)
            {
                output.WriteValueU32(this.Unknown34);

                // Unknown35
                {
                    output.WriteValueS32(this.Unknown35.Count);
                    foreach (UInt32 value in this.Unknown35)
                    {
                        output.WriteValueU32(value);
                    }
                }
            }

            if (this.ExtraDataVersion >= 33)
            {
                // Unknown36
                {
                    output.WriteValueS32(this.Unknown36.Count);
                    foreach (UInt32 value in this.Unknown36)
                    {
                        output.WriteValueU32(value);
                    }
                }
            }

            if (this.ExtraDataVersion >= 34)
            {
                // Echo Zones
                {
                    output.WriteValueS32(this.EchoZones.Count);
                    foreach (EchoZone echoZone in this.EchoZones)
                    {
                        echoZone.Serialize(output);
                    }
                }
            }

            if (this.ExtraDataVersion >= 35)
            {
                // Unknown38
                {
                    output.WriteValueS32(this.Unknown38.Length);
                    output.Write(this.Unknown38, 0, this.Unknown38.Length);
                }
            }
        }

        public static Player Default(Character character)
        {
            Player player = new Player();

            player.SaveTime = "20091026224303";

            // Version
            player.Version = 35;
            player.ExtraDataVersion = 35;

            // Zone
            player.CurrentZone = "None";

            // Attributes
            player.Level = 1;
            player.Experience = 0;
            player.Money = 80;

            if (character == Character.Berserker)
            {
                player.ClassType = "gd_Brick.Character.CharacterClass_Brick";
            }
            else
            {
                throw new Exception();
            }

            // Backpack
            player.BackpackCount = 2;
            player.BackpackSize = 12;

            // Weapons
            if (character == Character.Berserker)
            {
                // Shitty Shotgun HOORAY~
                player.Weapons.Add(
                    new Weapon()
                    {
                        Grade = "gd_itemgrades.StarterGear.ItemGrade_StarterGear",

                        Type = "gd_weap_combat_shotgun.A_Weapon.WeaponType_combat_shotgun",
                        
                        Prefix = "gd_weap_names_shared.Prefix_Starter.Prefix__BrickShotgun_Busted",
                        Title = "gd_weap_combat_shotgun.Title.Title__Shotgun",
                        Manufacturer = "gd_manufacturers.Manufacturers.Vladof",

                        ClipSize = 0,
                        EquipSlot = 1,
                        IsEquipped = 0,

                        Accuracy = "None",
                        Action = "None",
                        Barrel = "gd_weap_combat_shotgun.Barrel.barrel2",
                        Body = "gd_weap_combat_shotgun.Body.body1",
                        Grip = "gd_weap_combat_shotgun.Grip.grip3a",
                        Magazine = "gd_weap_combat_shotgun.mag.mag1",
                        Material = "gd_weap_shared_materialparts.ManufacturerMaterials.Material_Vladof_0_starter",
                        Sight = "gd_weap_combat_shotgun.Sight.sightnone",
                        Stock = "gd_weap_combat_shotgun.Stock.stock_none",
                    });
            }
            else
            {
                throw new Exception();
            }

            // Ammo
            if (character == Character.Berserker)
            {
                // Shotgun Ammo
                player.AmmoPools.Add(
                    new AmmoPool()
                    {
                        Name = "d_resources.AmmoResources.Ammo_Combat_Shotgun",
                        Pool = "d_resourcepools.AmmoPools.Ammo_Combat_Shotgun_Pool",
                        Quantity = 30.0f,
                        UpgradeLevel = 0,
                    });
            }
            else
            {
                throw new Exception();
            }

            // New-U

            if (character == Character.Berserker)
            {
                player.Name = "Brick";
            }
            else
            {
                throw new Exception();
            }

            player.Color1 = 0xFF667391;
            player.Color2 = 0xFF667391;
            player.Color3 = 0xFF6699B3;

            // Missions
            MissionZone missionZone;

            missionZone = new MissionZone();
            missionZone.Unknown0 = 0;
            missionZone.Name = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add(
                new Mission()
                {
                    Name = "Z0_Missions.Missions.M_IntroStateSaver",
                    Unknown1 = 2,
                    Unknown2 = 0,
                    Unknown3 = 0,
                });
            player.MissionZones.Add(missionZone);

            missionZone = new MissionZone();
            missionZone.Unknown0 = 1;
            missionZone.Name = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add(
                new Mission()
                {
                    Name = "Z0_Missions.Missions.M_IntroStateSaver",
                    Unknown1 = 2,
                    Unknown2 = 0,
                    Unknown3 = 0,
                });
            player.MissionZones.Add(missionZone);

            missionZone = new MissionZone();
            missionZone.Unknown0 = 2;
            missionZone.Name = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add(
                new Mission()
                {
                    Name = "Z0_Missions.Missions.M_IntroStateSaver",
                    Unknown1 = 2,
                    Unknown2 = 0,
                    Unknown3 = 0,
                });
            player.MissionZones.Add(missionZone);


            // Echo Zones
            player.EchoZones.Add(
                new EchoZone()
                {
                    Unknown0 = 0,
                });

            // Unknowns
            player.Unknown02 = 0;
            player.Unknown03 = 0;
            player.Unknown05 = 0;
            player.Unknown07 = 0;
            player.Unknown08 = 0;
            player.Unknown09 = 0;
            player.Unknown10 = 0;
            player.Unknown21 = "";
            player.Unknown22 = 26;
            player.Unknown23 = 42915336;
            player.Unknown24 = 3;
            player.Unknown26 = 1;
            player.Unknown28 = 247;
            player.Unknown34 = 0;

            return player;
        }
    }
}
