using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Models
{
    public class Ability
    {
        public class AbilitiesUpdatedEvent : PubSubEvent<Ability> { }
        public int DBID { get; set; }
        public int tempID { get; set; }
        public string Name { get; set; }
        public int CharacterDbId { get; set; }
        public string When { get; set; }
        public string Effect { get; set; }
    }
}
