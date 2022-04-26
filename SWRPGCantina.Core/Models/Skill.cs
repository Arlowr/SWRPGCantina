using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Models
{
    public class Skill
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool Career { get; set; }
        public bool IsWeaponSkill { get; set; }
        public bool IsKnowledgeSkill { get; set; }
    }
}
