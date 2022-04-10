using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.Models
{
    public class NPC : Character
    {
        public string CharacterDescription { get; set; }
        public string PCLink { get; set; }
        public string NPCType { get; set; }
        public string Source { get; set; }
    }
}
