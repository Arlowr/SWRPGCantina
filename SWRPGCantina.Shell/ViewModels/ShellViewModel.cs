using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Configuration;
using System.Windows;
using SWRPGCantina.Core.Generics;
using static System.Windows.Application;
using System.Diagnostics;

namespace SWRPGCantina.Shell.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> WindowCommand { get; private set; }
        public DelegateCommand ToSettingsCommand { get; private set; }
        public DelegateCommand ToHomeCommand { get; private set; }
        public ShellViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            WindowCommand = new DelegateCommand<string>(WindowCommandHandler);
            ToSettingsCommand = new DelegateCommand(ToSettingsCommandHandler);
            ToHomeCommand = new DelegateCommand(ToHomeCommandHandler);
            _regionManager = regionManager;

            StartUp();
        }

        private void StartUp()
        {
            SetDatabaseForDebug();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            generics.databaseLoc = config.AppSettings.Settings["DatabaseLocation"].Value;
        }

        private void ToHomeCommandHandler()
        {
            _regionManager.RequestNavigate("ContentRegion", "WelcomePageView", Callback);
        }

        private void ToSettingsCommandHandler()
        {
            _regionManager.RequestNavigate("ContentRegion", "DataSettingsView", Callback);
        }

        private void Callback(NavigationResult result)
        {
            if (result.Error != null)
            {

            }
        }

        private void WindowCommandHandler(string commandType)
        {
            switch (commandType)
            {
                case "Minimise":
                    SystemCommands.MinimizeWindow(Current.MainWindow);
                    break;
                case "Resize":
                    if (Current.MainWindow.WindowState == WindowState.Maximized)
                        SystemCommands.RestoreWindow(Current.MainWindow);
                    else if (Current.MainWindow.WindowState == WindowState.Normal)
                        SystemCommands.MaximizeWindow(Current.MainWindow);
                    break;
                case "Close":
                    SystemCommands.CloseWindow(Current.MainWindow);
                    break;
            }
        }

        [Conditional("DEBUG")]
        private void SetDatabaseForDebug()
        {
            string DatabaseLoc = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EncounterCantinaSWRPG";
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["DatabaseLocation"].Value = DatabaseLoc;
            configuration.Save();
            generics.databaseLoc = DatabaseLoc;

        }
    }
}
