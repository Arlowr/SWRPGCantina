using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWRPGCantina.Core.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core
{
    public class CoreModule : IModule
    {
        public readonly IRegionManager _regionManager;
        public CoreModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
                _regionManager.RegisterViewWithRegion("ContentRegion", typeof(WelcomePageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WelcomePageView>();
        }
    }
}
