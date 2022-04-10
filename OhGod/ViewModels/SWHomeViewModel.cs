using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWRPGCantina.TheCantina.ViewModels
{
    public class SWHomeViewModel : BindableBase
    {
        private readonly IRegionManager _regionManger;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand ToPlayerCreatorCommand { get; private set; }
        public DelegateCommand ToNPCCreatorCommand { get; private set; }
        public DelegateCommand ToSpecsAndTalentsCommand { get; private set; }
        public SWHomeViewModel(IRegionManager regionManger)
        {
            _regionManger = regionManger;
            NavigateCommand = new DelegateCommand<string>(NavigateCommandHandler);
        }

        private void NavigateCommandHandler(string whichScreen)
        {
            switch (whichScreen)
            {
                case "EncounterCreator":
                    break;
                case "Players":
                    break;
                case "NPCs":
                    _regionManger.RequestNavigate("SWContentRegion", "NPCsMainView");
                    break;
                case "SpecsAndTalents":
                    break;
                default:
                    break;
            }
        }
    }
}
