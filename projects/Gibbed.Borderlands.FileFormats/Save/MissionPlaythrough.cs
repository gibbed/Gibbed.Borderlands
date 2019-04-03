using System.Collections.Generic;

namespace Gibbed.Borderlands.FileFormats.Save
{
    public class MissionPlaythrough
    {
        public uint Playthrough;
        public string ActiveMission;
        public List<Mission> Missions = new List<Mission>();

        public void Deserialize(SaveStream input)
        {
            this.Playthrough = input.ReadValueU32();
            this.ActiveMission = input.ReadString();

            // Missions
            {
                uint count = input.ReadValueU32();
                this.Missions.Clear();
                for (uint i = 0; i < count; i++)
                {
                    Mission mission = new Mission();
                    mission.Deserialize(input);
                    this.Missions.Add(mission);
                }
            }
        }

        public void Serialize(SaveStream output)
        {
            output.WriteValueU32(this.Playthrough);
            output.WriteString(this.ActiveMission);

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
}
