using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Models
{
    public class Talent
    {
        public class TalentUpdatedEvent : PubSubEvent<Talent> { }
        public int DbId { get; set; }
        public string Name { get; set; }
        public bool NeedsRanks { get; set; }
        public string Description { get; set; }
        public bool IsForceTalent { get; set; }
        public bool IsActiveTalent { get; set; }
        public string StatIncreaseName { get; set; }
        public int StatIncrease { get; set; }

        public int Rank { get; set; }
        public int CharacterDBInt { get; set; }

    }
}
