using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.Models
{
    public class PlayerCharacter: Character
    {
        public string PlayerName { get; set; }
        public int Morality { get; set; }
        public int Obligation { get; set; }
        public string ObligationDescription { get; set; }
        public int Obligation2 { get; set; }
        public string Obligation2Description { get; set; }
        public int Obligation3 { get; set; }
        public string Obligation3Description { get; set; }
        public int TotalXP { get; set; }
        public int AvailableXP { get; set; }
    }
}
