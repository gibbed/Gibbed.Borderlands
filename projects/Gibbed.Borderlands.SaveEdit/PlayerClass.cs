using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.Borderlands.SaveEdit
{
    internal class PlayerClass
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public PlayerClass(string type, string name)
        {
            this.Type = type;
            this.Name = name;
        }
    }
}
