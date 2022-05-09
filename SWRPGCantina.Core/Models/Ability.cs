using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Models
{
    public class Ability
    {
        public string Name { get; set; }
        public int CharacterDbId { get; set; }
        public string When { get; set; }
        public string Effect { get; set; }
    }
}
