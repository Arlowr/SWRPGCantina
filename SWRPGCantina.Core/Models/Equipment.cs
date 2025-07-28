using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Models
{
    public class Equipment
    {
        public int DbId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Encumbrance { get; set; }
        public int Rarity { get; set; }
        public string Special { get; set; }
    }
}
