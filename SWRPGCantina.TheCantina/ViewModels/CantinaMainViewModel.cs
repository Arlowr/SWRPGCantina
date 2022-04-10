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

            _regionManager.RequestNavigate("SWContentRegion", "SWHomeView");
        }

        private void SWRPGToPageCommandHandler(string page)
        {
            switch (page)
            {
                case "EncounterCreator":
                    break;
                case "PlayerCreator":
                    break;
                case "NPCCreator":
                    _regionManager.RequestNavigate("SWContentRegion", "NPCsMainView");
                    break;
            }
        }

        private void ToSWRPGHomeCommandHandler()
        {
            _regionManager.RequestNavigate("SWContentRegion", "SWHomeView");
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
            _regionManager.RequestNavigate("SWContentRegion", "SWHomeView");

        }
    }
}
