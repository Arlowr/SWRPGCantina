using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWRPGCantina.TheCantina.ViewModels.SkillsAndTalents
{
    public class SkillsTalentsMainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public SkillsTalentsMainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(NavigateCommandHandler);
        }

        private void NavigateCommandHandler(string whichScreen)
        {
            switch (whichScreen)
            {
                case "Careers":
                    //_regionManger.RequestNavigate("SkillTalentRegion", "CareersMainview");
                    break;
                case "Talents":
                    _regionManager.RequestNavigate("SkillTalentRegion", "TalentsView");
                    break;
                case "Abilties":
                    //_regionManger.RequestNavigate("SkillTalentRegion", "AbilitiesView");
                    break;
                default:
                    break;
            }
        }
    }
}
