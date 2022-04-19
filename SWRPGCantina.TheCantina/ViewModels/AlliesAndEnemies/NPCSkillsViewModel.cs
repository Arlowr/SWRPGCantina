using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCSkillsViewModel : BindableBase
    {
        public DelegateCommand<string> ChangeSkillRankCommand { get; private set; }
        NPCCharacterMainViewModel NPCCharacterMainViewModel { get; }

        public NPCSkillsViewModel()
        {
            ChangeSkillRankCommand = new DelegateCommand<string>(ChangeSkillRank);
        }

        public NPCSkillsViewModel(NPCCharacterMainViewModel npcCharacterMainViewModel)
        {
            NPCCharacterMainViewModel = npcCharacterMainViewModel;
            ChangeSkillRankCommand = new DelegateCommand<string>(ChangeSkillRank);
        }

        private void ChangeSkillRank(string whichCommand)
        {
            string whichSkill = whichCommand.Substring(0, whichCommand.Length - 5);
            string whichChange = whichCommand.Substring(whichCommand.Length - 5);
            string actualSkillName = "";

            int incdec = 1;
            if (whichChange == "Lower")
                incdec = -1;
            else
                incdec = 1;

            switch (whichSkill)
            {
                case "Astro":
                    actualSkillName = "Astrogation";
                    break;
                default:
                    break;
            }

            NPCCharacterMainViewModel.NPC.Skills.FirstOrDefault(x => x.Name == "Astrogation").Rank = NPCCharacterMainViewModel.NPC.Skills.FirstOrDefault(x => x.Name == "Astrogation").Rank + incdec;
        }

    }
}
