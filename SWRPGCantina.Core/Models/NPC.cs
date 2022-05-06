using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Models
{
    public class NPC : Character
    {
        public class NPCUpdatedEvent : PubSubEvent<NPC> { }
        public class NPCDBUpdatedEvent : PubSubEvent { }

        public string CharacterDescription { get; set; }
        public string PCLink { get; set; }
        public string NPCType { get; set; }
        public string NPCAlignment { get; set; }
        public string NPCAffiliation { get; set; }
        public string Source { get; set; }
        public int RarityRank { get; set; }
    }
}
