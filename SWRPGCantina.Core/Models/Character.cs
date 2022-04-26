using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Models
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

        public Skill Astrogation { get; set; }
        public Skill Athletics { get; set; }
        public Skill Charm { get; set; }
        public Skill Coercion { get; set; }
        public Skill Computers { get; set; }
        public Skill Cool { get; set; }
        public Skill Coordination { get; set; }
        public Skill Deception { get; set; }
        public Skill Discipline { get; set; }
        public Skill Leadership { get; set; }
        public Skill Mechanics { get; set; }
        public Skill Medicine { get; set; }
        public Skill Negotiation { get; set; }
        public Skill Perception { get; set; }
        public Skill PilotingPlanetary { get; set; }
        public Skill PilotingSpace { get; set; }
        public Skill Resilience { get; set; }
        public Skill Skullduggery { get; set; }
        public Skill Stealth { get; set; }
        public Skill Streetwise { get; set; }
        public Skill Survival { get; set; }
        public Skill Vigilance { get; set; }
        public Skill Brawl { get; set; }
        public Skill Gunnery { get; set; }
        public Skill Lightsaber { get; set; }
        public Skill Melee { get; set; }
        public Skill RangedLight { get; set; }
        public Skill RangedHeavy { get; set; }
        public Skill CoreWorldKnow { get; set; }
        public Skill EducationKnow { get; set; }
        public Skill LoreKnow { get; set; }
        public Skill OuterRimKnow { get; set; }
        public Skill UnderworldKnow { get; set; }
        public Skill WarfareKnow { get; set; }
        public Skill XenologyKnow { get; set; }
    }
}
