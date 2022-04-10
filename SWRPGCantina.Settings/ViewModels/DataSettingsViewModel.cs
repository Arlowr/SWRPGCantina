using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Generics;
using System;
using System.Configuration;

namespace SWRPGCantina.Settings.ViewModels
{
    public class DataSettingsViewModel : BindableBase
    {
        public string Title => "Data Control";

        private string _databaseLocation;
        public string DatabaseLocation
        {
            get { return _databaseLocation; }
            set { SetProperty(ref _databaseLocation, value); }
        }

        private string _startingDatabaseLocation;
        public string StartingDatabaseLocation
        {
            get { return _startingDatabaseLocation; }
            set { SetProperty(ref _startingDatabaseLocation, value); }
        }

        public DelegateCommand SaveDataInfoCommand { get; }
        public DelegateCommand DefaultDBCommand { get; }

        public DataSettingsViewModel()
        {
            SaveDataInfoCommand = new DelegateCommand(SaveData, AllowedToSave);
            DefaultDBCommand = new DelegateCommand(GetDefaultDB);

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            DatabaseLocation = configuration.AppSettings.Settings["DatabaseLocation"].Value;
            StartingDatabaseLocation = configuration.AppSettings.Settings["DatabaseLocation"].Value;

        }

        private bool AllowedToSave()
        {
            return !string.IsNullOrEmpty(DatabaseLocation);
        }

        private void GetDefaultDB()
        {
            DatabaseLocation = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EncounterCantinaSWRPG";

            SaveDataInfoCommand.RaiseCanExecuteChanged();
        }

        private void SaveData()
        {
            try
            {
                if (StartingDatabaseLocation != DatabaseLocation)
                {
                    int resultOfCopy = CopyDatabaseToCorrectLocation();

                    if (resultOfCopy == 1)
                    {
                        Created = false;
                        Saved = true;
                    } else if (resultOfCopy == 2)
                    {
                        Created = true;
                        Saved = false;
                    }
                    else
                    {
                        Created = false;
                        Saved = false;
                    }
                }
                else
                    Saved = true;

                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                configuration.AppSettings.Settings["DatabaseLocation"].Value = DatabaseLocation;

                configuration.Save();


                generics.databaseLoc = configuration.AppSettings.Settings["DatabaseLocation"].Value;
            }
            catch (Exception)
            {
                Saved = false;
            }

        }

        private int CopyDatabaseToCorrectLocation()
        {
            int result = 0;

            //try
            //{

            //}
            //catch (Exception)
            //{
            //    result = 0;
            //}

            return result;
        }

        private bool _saved;
        public bool Saved
        {
            get { return _saved; }
            set 
            { 
                SetProperty(ref _saved, value);
                if (Saved)
                    Created = false;
            }
        }
        private bool _created;
        public bool Created
        {
            get { return _created; }
            set 
            { 
                SetProperty(ref _created, value);
                if (Created)
                    Saved = false;
            }
        }
    }
}
