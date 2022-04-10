using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.Models
{
    public class Character
    {
        public int DBID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public string EyeColour { get; set; }
        public string Build { get; set; }
        public string HairColour { get; set; }
        public int Age { get; set; }
        public int Brawn { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Cunning { get; set; }
        public int Willpower { get; set; }
        public int Presence { get; set; }
        public int ForceRating { get; set; }
        public int WoundThreshold { get; set; }
        public int CurrentWounds { get; set; }
        public int StrainThreshold { get; set; }
        public int CurrentStrain { get; set; }
        public int Soak { get; set; }
        public int DefenceMelee { get; set; }
        public int DefenceRanged { get; set; }
        public int ForcePoolCommited { get; set; }
        public int ForcePoolAvailable { get; set; }
        public List<Armour> Armour { get; set; }
        public List<Weapon> Weapons { get; set; }

        public List<Ability> Abilities { get; set; }
        public List<Talent> Talents { get; set; }
        public List<Injury> Injuries { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
