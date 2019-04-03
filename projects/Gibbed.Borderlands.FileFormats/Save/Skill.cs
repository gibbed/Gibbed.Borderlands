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
namespace Gibbed.Borderlands.FileFormats.Save
{
    public class Skill
    {
        public string Name { get; set; }
        public uint Level { get; set; }
        public uint Experience { get; set; }
        public int ArtifactMode { get; set; }

        public void Deserialize(SaveStream input)
        {
            this.Name = input.ReadString();
            this.Level = input.ReadValueU32();
            this.Experience = input.ReadValueU32();
            this.ArtifactMode = input.ReadValueS32();
        }

        public void Serialize(SaveStream output)
        {
            output.WriteString(this.Name);
            output.WriteValueU32(this.Level);
            output.WriteValueU32(this.Experience);
            output.WriteValueS32(this.ArtifactMode);
        }
    }
}
