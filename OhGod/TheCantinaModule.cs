using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWRPGCantina.TheCantina.Views;
using SWRPGCantina.TheCantina.Views.AlliesAndEnemies;

namespace SWRPGCantina.TheCantina
{
    public class TheCantinaModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CantinaMainView>();
            containerRegistry.RegisterForNavigation<SWHomeView>();
            containerRegistry.RegisterForNavigation<NPCsMainView>();
        }
    }
}