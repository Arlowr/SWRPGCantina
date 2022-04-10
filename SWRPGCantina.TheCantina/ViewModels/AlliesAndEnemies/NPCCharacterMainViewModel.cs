using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Generics;
using SWRPGCantina.TheCantina.Database;
using SWRPGCantina.TheCantina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCCharacterMainViewModel: BindableBase, INavigationAware
    {
        private string _tabTitle;
        public string TabTitle
        {
            get { return _tabTitle; }
            set { SetProperty(ref _tabTitle, value); }
        }

        private string _NPCDetailsWindowName;
        public string NPCDetailsWindowName
        {
            get { return _NPCDetailsWindowName; }
            set { SetProperty(ref _NPCDetailsWindowName, value); }
        }

        private NPC _NPC;
        public NPC NPC
        {
            get { return _NPC; }
            set { SetProperty(ref _NPC, value); }
        }

        private List<string> _NPCTypes;
        public List<string> NPCTypes
        {
            get { return _NPCTypes; }
            set { SetProperty(ref _NPCTypes, value); }
        }

        private bool _updatedNPC;
        public bool UpdatedNPC
        {
            get { return _updatedNPC; }
            set { SetProperty(ref _updatedNPC, value); }
        }

        private bool _updateNPCSucess;
        public bool UpdateNPCSucess
        {
            get { return _updateNPCSucess; }
            set { SetProperty(ref _updateNPCSucess, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand<string> NPCDetailsWindowCommand { get; private set; }
        
        public NPCCharacterMainViewModel()
        {
            UpdateCommand = new DelegateCommand(UpdateNPC, CanUpdateNPC);
            NPCDetailsWindowCommand = new DelegateCommand<string>(OpenDetailsWindow);


            NPCTypes = new List<string>{ "None", "Neutral", "Enemy", "Ally" };
            UpdatedNPC = false; UpdateNPCSucess = false;
        }

        private void OpenDetailsWindow(string windowToOpen)
        {
            
        }

        private bool CanUpdateNPC()
        {
            return true;
        }

        private void UpdateNPC()
        {
            UpdatedNPC = false;

            AlliesAndEnemiesDBControl dbConnection = new AlliesAndEnemiesDBControl();
            UpdateNPCSucess = dbConnection.AddOrUpdateAdversary(NPC);

            UpdatedNPC = true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("NPC"))
                NPC = navigationContext.Parameters.GetValue<NPC>("NPC");

            if (NPC != null)
            {
                TabTitle = NPC.Name;
                NPCDetailsWindowName = NPC.Name.Replace(" ", "") + "DetailsWindow";
            }
            else
            {
                TabTitle = "New";
                NPCDetailsWindowName = "NewNPCDetailsWindow";
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var newNPC = navigationContext.Parameters.GetValue<NPC>("NPC");

            if (newNPC != null)
            {
                if (NPC.Name != newNPC.Name)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
