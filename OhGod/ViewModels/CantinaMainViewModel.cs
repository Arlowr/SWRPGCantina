using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWRPGCantina.TheCantina.ViewModels
{
    public class CantinaMainViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand ToSWRPGHomeCommand { get; private set; }
        public DelegateCommand<string> SWRPGToPageCommand { get; private set; }
        public CantinaMainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ToSWRPGHomeCommand = new DelegateCommand(ToSWRPGHomeCommandHandler);
            SWRPGToPageCommand = new DelegateCommand<string>(SWRPGToPageCommandHandler);

            _regionManager.RequestNavigate("SWContentRegion", "SWRPGHomeView");
        }

        private void SWRPGToPageCommandHandler(string page)
        {
            switch (page)
            {
                case "EncounterCreator":
                    _regionManager.RequestNavigate("SWContentRegion", "SWRPGEncounterCreatorCreatorView");
                    break;
                case "PlayerCreator":
                    _regionManager.RequestNavigate("SWContentRegion", "SWRPGPlayerCreatorView");
                    break;
                case "NPCCreator":
                    _regionManager.RequestNavigate("SWContentRegion", "SWRPGNPCCreatorView");
                    break;
            }
        }

        private void ToSWRPGHomeCommandHandler()
        {
            _regionManager.RequestNavigate("SWContentRegion", "SWRPGHomeView");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _regionManager.RequestNavigate("SWContentRegion", "SWRPGHomeView");

        }
    }
}
