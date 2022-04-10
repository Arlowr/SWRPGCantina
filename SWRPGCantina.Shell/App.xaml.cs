using SWRPGCantina.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using SWRPGCantina.Core;
using SWRPGCantina.Settings;
using SWRPGCantina.TheCantina;

namespace SWRPGCantina.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CoreModule>();
            moduleCatalog.AddModule<SettingsModule>();
            moduleCatalog.AddModule<TheCantinaModule>();
        }
    }
}
