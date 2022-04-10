using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWRPGCantina.Settings.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Settings
{
    public class SettingsModule : IModule
    {
        public readonly IRegionManager _regionManager;
        public SettingsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DataSettingsView>();
        }
    }
}
