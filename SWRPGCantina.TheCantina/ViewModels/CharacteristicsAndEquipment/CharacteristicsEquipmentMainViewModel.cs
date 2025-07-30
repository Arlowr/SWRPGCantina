using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWRPGCantina.TheCantina.ViewModels.CharacteristicsAndEquipment
{
    public class CharacteristicsEquipmentMainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public CharacteristicsEquipmentMainViewModel(IRegionManager regionManager)
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
                case "Weapons":
                    //_regionManager.RequestNavigate("SkillTalentRegion", "WeaponsView");
                    break;
                case "Armour":
                    //_regionManager.RequestNavigate("SkillTalentRegion", "ArmourView");
                    break;
                case "Equipment":
                    _regionManager.RequestNavigate("SkillTalentRegion", "EquipmentView");
                    break;
                default:
                    break;
            }
        }
    }
}
