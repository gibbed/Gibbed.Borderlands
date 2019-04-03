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
