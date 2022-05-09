using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWRPGCantina.TheCantina.Views;
using SWRPGCantina.TheCantina.Views.AlliesAndEnemies;
using SWRPGCantina.TheCantina.Views.SkillsAndTalents;

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
            containerRegistry.RegisterForNavigation<NPCMainView>(); 
            containerRegistry.RegisterForNavigation<NPCSkillsView>();
            containerRegistry.RegisterForNavigation<NPCMinionMainView>();
            containerRegistry.RegisterForNavigation<NPCMinionSkillsView>();
            containerRegistry.RegisterForNavigation<NPCTalentsView>();
            containerRegistry.RegisterForNavigation<NPCAbilitiesMainView>();
            containerRegistry.RegisterForNavigation<SkillsTalentsMainView>();
            containerRegistry.RegisterForNavigation<TalentCreationView>();
            containerRegistry.RegisterForNavigation<TalentsView>();
        }
    }
}