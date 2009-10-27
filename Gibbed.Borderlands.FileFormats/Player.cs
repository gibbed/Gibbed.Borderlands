using System;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Borderlands.FileFormats
{
    public class Player
    {
        public class Skill
        {
            public UInt32 Level;
            public UInt32 Experience;
            public UInt32 Unknown2;

            public void Deserialize(Stream input)
            {
                this.Level = input.ReadValueU32();
                this.Experience = input.ReadValueU32();
                this.Unknown2 = input.ReadValueU32();
            }

            public void Serialize(Stream output)
            {
                output.WriteValueU32(this.Level);
                output.WriteValueU32(this.Experience);
                output.WriteValueU32(this.Unknown2);
            }

            public override string ToString()
            {
                string rez = "";

                rez += "Level " + this.Level.ToString();

                if (this.Experience > 0)
                {
                    rez += ", XP " + this.Experience.ToString();
                }

                if (this.Unknown2 != 0xFFFFFFFF)
                {
                    rez += ", " + this.Unknown2.ToString("X8");
                }

                return rez;
            }
        }

        public class AmmoPool
        {
            public string Unknown0;
            public string Unknown1;
            public float Unknown2;
            public UInt32 Unknown3;

            public void Deserialize(Stream input)
            {
                this.Unknown0 = input.ReadStringASCIIU32();
                this.Unknown1 = input.ReadStringASCIIU32();
                this.Unknown2 = input.ReadValueF32();
                this.Unknown3 = input.ReadValueU32();
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Unknown0);
                output.WriteStringASCIIU32(this.Unknown1);
                output.WriteValueF32(this.Unknown2);
                output.WriteValueU32(this.Unknown3);
            }
        }

        public class Item
        {
            public string Unknown00;
            public string Unknown01;
            public string Unknown02;
            public string Unknown03;
            public string Unknown04;
            public string Unknown05;
            public string Unknown06;
            public string Unknown07;
            public string Unknown08;
            public UInt32 Unknown09;
            public UInt32 IsEquipped;
            public UInt32 EquipSlot;

            public void Deserialize(Stream input)
            {
                this.Unknown00 = input.ReadStringASCIIU32();
                this.Unknown01 = input.ReadStringASCIIU32();
                this.Unknown02 = input.ReadStringASCIIU32();
                this.Unknown03 = input.ReadStringASCIIU32();
                this.Unknown04 = input.ReadStringASCIIU32();
                this.Unknown05 = input.ReadStringASCIIU32();
                this.Unknown06 = input.ReadStringASCIIU32();
                this.Unknown07 = input.ReadStringASCIIU32();
                this.Unknown08 = input.ReadStringASCIIU32();
                this.Unknown09 = input.ReadValueU32();
                this.IsEquipped = input.ReadValueU32();
                this.EquipSlot = input.ReadValueU32();
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Unknown00);
                output.WriteStringASCIIU32(this.Unknown01);
                output.WriteStringASCIIU32(this.Unknown02);
                output.WriteStringASCIIU32(this.Unknown03);
                output.WriteStringASCIIU32(this.Unknown04);
                output.WriteStringASCIIU32(this.Unknown05);
                output.WriteStringASCIIU32(this.Unknown06);
                output.WriteStringASCIIU32(this.Unknown07);
                output.WriteStringASCIIU32(this.Unknown08);
                output.WriteValueU32(this.Unknown09);
                output.WriteValueU32(this.IsEquipped);
                output.WriteValueU32(this.EquipSlot);
            }
        }

        public struct Weapon
        {
            public string Grade;
            public string Manufacturer;
            public string Type;
            public string ModelBody;
            public string ModelGrip;
            public string ModelMagazine;
            public string ModelBarrel;
            public string ModelSight;
            public string ModelStock;
            public string ModelAction;
            public string ModelAccuracy;
            public string ModelMaterial;
            public string Prefix;
            public string Title;
            public UInt32 ClipSize;
            public UInt32 IsEquipped;
            public UInt32 EquipSlot;

            public void Deserialize(Stream input)
            {
                this.Grade = input.ReadStringASCIIU32();
                this.Manufacturer = input.ReadStringASCIIU32();
                this.Type = input.ReadStringASCIIU32();
                this.ModelBody = input.ReadStringASCIIU32();
                this.ModelGrip = input.ReadStringASCIIU32();
                this.ModelMagazine = input.ReadStringASCIIU32();
                this.ModelBarrel = input.ReadStringASCIIU32();
                this.ModelSight = input.ReadStringASCIIU32();
                this.ModelStock = input.ReadStringASCIIU32();
                this.ModelAction = input.ReadStringASCIIU32();
                this.ModelAccuracy = input.ReadStringASCIIU32();
                this.ModelMaterial = input.ReadStringASCIIU32();
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
                output.WriteStringASCIIU32(this.ModelBody);
                output.WriteStringASCIIU32(this.ModelGrip);
                output.WriteStringASCIIU32(this.ModelMagazine);
                output.WriteStringASCIIU32(this.ModelBarrel);
                output.WriteStringASCIIU32(this.ModelSight);
                output.WriteStringASCIIU32(this.ModelStock);
                output.WriteStringASCIIU32(this.ModelAction);
                output.WriteStringASCIIU32(this.ModelAccuracy);
                output.WriteStringASCIIU32(this.ModelMaterial);
                output.WriteStringASCIIU32(this.Prefix);
                output.WriteStringASCIIU32(this.Title);
                output.WriteValueU32(this.ClipSize);
                output.WriteValueU32(this.IsEquipped);
                output.WriteValueU32(this.EquipSlot);
            }
        }

        public class Mission
        {
            public class Unknown3
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

            public UInt32 Unknown0;
            public UInt32 Unknown1;
            public UInt32 Unknown2;
            public List<Unknown3> Unknown3s = new List<Unknown3>();

            public void Deserialize(Stream input)
            {
                this.Unknown0 = input.ReadValueU32();
                this.Unknown1 = input.ReadValueU32();
                this.Unknown2 = input.ReadValueU32();

                // States
                {
                    uint count = input.ReadValueU32();
                    this.Unknown3s.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        Unknown3 unknown3 = new Unknown3();
                        unknown3.Deserialize(input);
                        this.Unknown3s.Add(unknown3);
                    }
                }
            }

            public void Serialize(Stream output)
            {
                output.WriteValueU32(this.Unknown0);
                output.WriteValueU32(this.Unknown1);
                output.WriteValueU32(this.Unknown2);

                // States
                {
                    output.WriteValueS32(this.Unknown3s.Count);
                    foreach (Unknown3 unknown3 in this.Unknown3s)
                    {
                        unknown3.Serialize(output);
                    }
                }
            }
        }

        public class MissionZone
        {
            public string Name;
            public Dictionary<string, Mission> Missions = new Dictionary<string, Mission>();

            public void Deserialize(Stream input)
            {
                this.Name = input.ReadStringASCIIU32();

                // Missions
                {
                    uint count = input.ReadValueU32();
                    this.Missions.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        string name = input.ReadStringASCIIU32();
                        Mission mission = new Mission();
                        mission.Deserialize(input);
                        this.Missions.Add(name, mission);
                    }
                }
            }

            public void Serialize(Stream output)
            {
                output.WriteStringASCIIU32(this.Name);

                // Missions
                {
                    output.WriteValueS32(this.Missions.Count);
                    foreach (KeyValuePair<string, Mission> mission in this.Missions)
                    {
                        output.WriteStringASCIIU32(mission.Key);
                        mission.Value.Serialize(output);
                    }
                }
            }
        }

        public class Echo
        {
            public UInt32 Unknown0;
            public UInt32 Unknown1;

            public void Deserialize(Stream input)
            {
                this.Unknown0 = input.ReadValueU32();
                this.Unknown1 = input.ReadValueU32();
            }

            public void Serialize(Stream output)
            {
                output.WriteValueU32(this.Unknown0);
                output.WriteValueU32(this.Unknown1);
            }
        }

        public class EchoZone
        {
            public Dictionary<string, Echo> Echoes = new Dictionary<string, Echo>();

            public void Deserialize(Stream input)
            {
                // Echos
                {
                    uint count = input.ReadValueU32();
                    this.Echoes.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        string name = input.ReadStringASCIIU32();
                        Echo echo = new Echo();
                        echo.Deserialize(input);
                        this.Echoes.Add(name, echo);
                    }
                }
            }

            public void Serialize(Stream output)
            {
                // Echos
                {
                    output.WriteValueS32(this.Echoes.Count);
                    foreach (KeyValuePair<string, Echo> echo in this.Echoes)
                    {
                        output.WriteStringASCIIU32(echo.Key);
                        echo.Value.Serialize(output);
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
        public Dictionary<string, Skill> Skills = new Dictionary<string, Skill>();
        public UInt32 Unknown07;
        public UInt32 Unknown08;
        public UInt32 Unknown09;
        public UInt32 Unknown10;
        public List<AmmoPool> AmmoPools = new List<AmmoPool>();
        public List<Item> Items = new List<Item>();
        public UInt32 BackpackSize { get; set; }
        public UInt32 BackpackCount;
        public List<Weapon> Weapons = new List<Weapon>();
        public byte[] Unknown16 = new byte[0];
        public List<string> VisitedZones = new List<string>();
        public string CurrentZone;
        //public ??? Unknown19 = ...
        //public ??? Unknown20 = ...
        public string Unknown21;
        public UInt32 Unknown22;
        public UInt32 Unknown23;
        public UInt32 Unknown24;
        public UInt32 ExtraDataVersion;
        public UInt32 Unknown26;
        public Dictionary<int, MissionZone> MissionZones = new Dictionary<int, MissionZone>();
        public UInt32 Unknown28;
        public string SaveTime;
        public string Name { get; set; }
        public UInt32 Color1;
        public UInt32 Color2;
        public UInt32 Color3;
        public UInt32 Unknown34;
        public List<UInt32> Unknown35 = new List<UInt32>();
        public List<UInt32> Unknown36 = new List<UInt32>();
        public Dictionary<int, EchoZone> EchoZones = new Dictionary<int, EchoZone>();
        public byte[] Unknown38 = new byte[0];

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
                    string name = input.ReadStringASCIIU32();
                    Skill skill = new Skill();
                    skill.Deserialize(input);
                    this.Skills.Add(name, skill);
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
                this.VisitedZones.Clear();
                for (uint i = 0; i < count; i++)
                {
                    this.VisitedZones.Add(input.ReadStringASCIIU32());
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
                        int index = input.ReadValueS32();
                        MissionZone missionZone = new MissionZone();
                        missionZone.Deserialize(input);
                        this.MissionZones.Add(index, missionZone);
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
                        int index = input.ReadValueS32();
                        EchoZone echoZone = new EchoZone();
                        echoZone.Deserialize(input);
                        this.EchoZones.Add(index, echoZone);
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
                foreach (KeyValuePair<string, Skill> skill in this.Skills)
                {
                    output.WriteStringASCIIU32(skill.Key);
                    skill.Value.Serialize(output);
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
                output.WriteValueS32(this.VisitedZones.Count);
                foreach (string visitedZone in this.VisitedZones)
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
                    foreach (KeyValuePair<int, MissionZone> missionZone in this.MissionZones)
                    {
                        output.WriteValueS32(missionZone.Key);
                        missionZone.Value.Serialize(output);
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
                    foreach (KeyValuePair<int, EchoZone> echoZone in this.EchoZones)
                    {
                        output.WriteValueS32(echoZone.Key);
                        echoZone.Value.Serialize(output);
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

                        ModelAccuracy = "None",
                        ModelAction = "None",
                        ModelBarrel = "gd_weap_combat_shotgun.Barrel.barrel2",
                        ModelBody = "gd_weap_combat_shotgun.Body.body1",
                        ModelGrip = "gd_weap_combat_shotgun.Grip.grip3a",
                        ModelMagazine = "gd_weap_combat_shotgun.mag.mag1",
                        ModelMaterial = "gd_weap_shared_materialparts.ManufacturerMaterials.Material_Vladof_0_starter",
                        ModelSight = "gd_weap_combat_shotgun.Sight.sightnone",
                        ModelStock = "gd_weap_combat_shotgun.Stock.stock_none",
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
                        Unknown0 = "d_resources.AmmoResources.Ammo_Combat_Shotgun",
                        Unknown1 = "d_resourcepools.AmmoPools.Ammo_Combat_Shotgun_Pool",
                        Unknown2 = 30.0f,
                        Unknown3 = 0,
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
            missionZone.Name = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add("Z0_Missions.Missions.M_IntroStateSaver",
                new Mission()
                {
                    Unknown0 = 2,
                    Unknown1 = 0,
                    Unknown2 = 0,
                });
            player.MissionZones.Add(0, missionZone);

            missionZone = new MissionZone();
            missionZone.Name = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add("Z0_Missions.Missions.M_IntroStateSaver",
                new Mission()
                {
                    Unknown0 = 2,
                    Unknown1 = 0,
                    Unknown2 = 0,
                });
            player.MissionZones.Add(1, missionZone);

            missionZone = new MissionZone();
            missionZone.Name = "Z0_Missions.Missions.M_IntroStateSaver";
            missionZone.Missions.Add("Z0_Missions.Missions.M_IntroStateSaver",
                new Mission()
                {
                    Unknown0 = 2,
                    Unknown1 = 0,
                    Unknown2 = 0,
                });
            player.MissionZones.Add(2, missionZone);


            // Echo Zones
            player.EchoZones.Add(0, new EchoZone());

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
