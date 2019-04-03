using System;
using System.Collections.Generic;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class Player
    {
        public uint Version;
        public string Character { get; set; }
        public uint Level { get; set; }
        public uint Experience { get; set; }
        public uint SkillPoints { get; set; }
        public uint Unknown03;
        public uint Money { get; set; }
        public uint MaybePlaythroughUnlocked { get; set; }
        public List<Skill> Skills { get; set; }
        public uint Unknown07;
        public uint Unknown08;
        public uint Unknown09;
        public uint Unknown10;
        public List<AmmoPool> AmmoPools { get; set; }
        public List<Item> Items { get; set; }
        public uint BackpackSlots { get; set; }
        public uint WeaponSlots { get; set; }
        public List<Weapon> Weapons { get; set; }
        public byte[] Stats = new byte[0];
        public List<string> VisitedStations { get; set; }
        public string CurrentStation { get; set; }
        //public ??? Unknown19 = ...
        //public ??? Unknown20 = ...
        public string Unknown21;
        public uint Unknown22;
        public uint Unknown23;
        public uint SaveSlot { get; set; } // Saving uses this to determin what save file to save over, LAME!
        public uint ExtraDataVersion;
        public uint Unknown26;
        public List<MissionPlaythrough> MissionPlaythroughs = new List<MissionPlaythrough>();
        public uint PlayTime; // If this is 0, both 'Time' and 'Save' on the load game screen will not be visible.
        public string SaveTime;
        public string Name { get; set; }
        public uint Color1;
        public uint Color2;
        public uint Color3;
        public uint Unknown34;
        public List<uint> Unknown35 = new List<UInt32>();
        public List<uint> Unknown36 = new List<UInt32>();
        public List<EchoPlaythrough> EchoPlaythroughs = new List<EchoPlaythrough>();
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
            this.VisitedStations = new List<string>();
        }

        public void Deserialize(SaveStream input)
        {
            if (input.ReadStaticString(4) != "PLYR")
            {
                throw new FormatException("not player data");
            }

            this.Version = input.ReadValueU32();
            if (this.Version != 35)
            {
                throw new FormatException("unsupported player data version (" + this.Version.ToString() + ")");
            }

            this.Character = input.ReadString();
            this.Level = input.ReadValueU32();
            this.Experience = input.ReadValueU32();
            this.SkillPoints = input.ReadValueU32();
            this.Unknown03 = input.ReadValueU32();
            this.Money = input.ReadValueU32();
            this.MaybePlaythroughUnlocked = input.ReadValueU32();

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

            this.BackpackSlots = input.ReadValueU32();
            this.WeaponSlots = input.ReadValueU32();

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

            this.Stats = input.ReadBuffer();

            // Visited Zones
            {
                uint count = input.ReadValueU32();
                this.VisitedStations.Clear();
                for (uint i = 0; i < count; i++)
                {
                    this.VisitedStations.Add(input.ReadString());
                }
            }

            this.CurrentStation = input.ReadString();

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

            this.Unknown21 = input.ReadString(); ;
            this.Unknown22 = input.ReadValueU32();
            this.Unknown23 = input.ReadValueU32();
            this.SaveSlot = input.ReadValueU32();
            this.ExtraDataVersion = input.ReadValueU32();

            if (this.ExtraDataVersion >= 27)
            {
                this.Unknown26 = input.ReadValueU32();
            }

            if (this.ExtraDataVersion >= 28 && this.ExtraDataVersion <= 31)
            {
                // junk
                input.ReadString();

                {
                    uint count = input.ReadValueU32();
                    for (uint i = 0; i < count; i++)
                    {
                        input.ReadString();
                    }
                }
            }

            if (this.ExtraDataVersion >= 29)
            {
                // Mission Zones
                {
                    uint count = input.ReadValueU32();
                    this.MissionPlaythroughs.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        MissionPlaythrough missionZone = new MissionPlaythrough();
                        missionZone.Deserialize(input);
                        this.MissionPlaythroughs.Add(missionZone);
                    }
                }
            }

            if (this.ExtraDataVersion >= 30)
            {
                this.PlayTime = input.ReadValueU32();
                this.SaveTime = input.ReadString();
            }

            if (this.ExtraDataVersion >= 31)
            {
                this.Name = input.ReadString();
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
                    this.EchoPlaythroughs.Clear();
                    for (uint i = 0; i < count; i++)
                    {
                        EchoPlaythrough echoZone = new EchoPlaythrough();
                        echoZone.Deserialize(input);
                        this.EchoPlaythroughs.Add(echoZone);
                    }
                }
            }

            if (this.ExtraDataVersion >= 35)
            {
                // Unknown38
                this.Unknown38 = input.ReadBuffer();
            }
        }

        public void Serialize(SaveStream output)
        {
            output.WriteStaticString("PLYR");
            output.WriteValueU32(this.Version);
            output.WriteString(this.Character);
            output.WriteValueU32(this.Level);
            output.WriteValueU32(this.Experience);
            output.WriteValueU32(this.SkillPoints);
            output.WriteValueU32(this.Unknown03);
            output.WriteValueU32(this.Money);
            output.WriteValueU32(this.MaybePlaythroughUnlocked);

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

            output.WriteValueU32(this.BackpackSlots);
            output.WriteValueU32(this.WeaponSlots);

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
                output.WriteBuffer(this.Stats);
            }

            // Visited Zones
            {
                output.WriteValueS32(this.VisitedStations.Count);
                foreach (string visitedZone in this.VisitedStations)
                {
                    output.WriteString(visitedZone);
                }
            }

            output.WriteString(this.CurrentStation);

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

            output.WriteString(this.Unknown21);
            output.WriteValueU32(this.Unknown22);
            output.WriteValueU32(this.Unknown23);
            output.WriteValueU32(this.SaveSlot);
            output.WriteValueU32(this.ExtraDataVersion);

            if (this.ExtraDataVersion >= 27)
            {
                output.WriteValueU32(this.Unknown26);
            }

            if (this.ExtraDataVersion >= 28 && this.ExtraDataVersion <= 31)
            {
                // junk
                output.WriteString("");
                output.WriteValueU32(0);
            }

            if (this.ExtraDataVersion >= 29)
            {
                // Mission Zones
                {
                    output.WriteValueS32(this.MissionPlaythroughs.Count);
                    foreach (MissionPlaythrough missionZone in this.MissionPlaythroughs)
                    {
                        missionZone.Serialize(output);
                    }
                }
            }

            if (this.ExtraDataVersion >= 30)
            {
                output.WriteValueU32(this.PlayTime);
                output.WriteString(this.SaveTime);
            }

            if (this.ExtraDataVersion >= 31)
            {
                output.WriteString(this.Name);
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
                    output.WriteValueS32(this.EchoPlaythroughs.Count);
                    foreach (EchoPlaythrough echoZone in this.EchoPlaythroughs)
                    {
                        echoZone.Serialize(output);
                    }
                }
            }

            if (this.ExtraDataVersion >= 35)
            {
                output.WriteBuffer(this.Unknown38);
            }
        }
    }
}
