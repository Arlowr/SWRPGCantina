using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Generics;
using SWRPGCantina.Core.Models;
using SWRPGCantina.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using static SWRPGCantina.Core.Models.NPC;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCCharacterMainViewModel: BindableBase, INavigationAware, INotifyPropertyChanged
    {
        private readonly IRegionManager _regionManager;
        protected readonly IEventAggregator _eventAggregator; 
        public event PropertyChangedEventHandler newPropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (newPropertyChanged != null)
            {
                newPropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private NPCSkillsViewModel _npcSkillsViewModel;
        public NPCSkillsViewModel npcSkillsViewModel
        {
            get { return _npcSkillsViewModel; }
            set { SetProperty(ref _npcSkillsViewModel, value); }
        }

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
            set
            {
                SetProperty(ref _NPC, value);
                Brawn = NPC.Brawn;
                Agility = NPC.Agility;
                Intellect = NPC.Intellect;
                Cunning = NPC.Cunning;
                Willpower = NPC.Willpower;
                Presence = NPC.Presence;
            }
        }

        private int _brawn;
        public int Brawn
        {
            get { return _brawn; }
            set 
            {
                value = Math.Min(6, value);
                value = Math.Max(1, value);
                SetProperty(ref _brawn, value);

                if (NPC.Brawn != Brawn)
                {
                    NPC.Brawn = Brawn;
                    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
                }

            }
        }
        private int _agility;
        public int Agility
        {
            get { return _agility; }
            set
            {
                value = Math.Min(6, value);
                value = Math.Max(1, value);
                SetProperty(ref _agility, value);

                if (NPC.Agility != Agility)
                {
                    NPC.Agility = Agility;
                    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
                }

            }
        }
        private int _intellect;
        public int Intellect
        {
            get { return _intellect; }
            set
            {
                value = Math.Min(6, value);
                value = Math.Max(1, value);
                SetProperty(ref _intellect, value);

                if (NPC.Intellect != Intellect)
                {
                    NPC.Intellect = Intellect;
                    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
                }

            }
        }
        private int _cunning;
        public int Cunning
        {
            get { return _cunning; }
            set
            {
                value = Math.Min(6, value);
                value = Math.Max(1, value);
                SetProperty(ref _cunning, value);

                if (NPC.Cunning != Cunning)
                {
                    NPC.Cunning = Cunning;
                    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
                }

            }
        }
        private int _willpower;
        public int Willpower
        {
            get { return _willpower; }
            set
            {
                value = Math.Min(6, value);
                value = Math.Max(1, value);
                SetProperty(ref _willpower, value);

                if (NPC.Willpower != Willpower)
                {
                    NPC.Willpower = Willpower;
                    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
                }

            }
        }
        private int _presence;
        public int Presence
        {
            get { return _presence; }
            set
            {
                value = Math.Min(6, value);
                value = Math.Max(1, value);
                SetProperty(ref _presence, value);

                if (NPC.Presence != Presence)
                {
                    NPC.Presence = Presence;
                    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
                }

            }
        }

        private List<string> _NPCAlignments;
        public List<string> NPCAlignments
        {
            get { return _NPCAlignments; }
            set { SetProperty(ref _NPCAlignments, value); }
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
        
        public NPCCharacterMainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<NPCUpdatedEvent>().Subscribe((NPC) =>
            {
                if (this.NPC.DBID == NPC.DBID)
                {
                    this.NPC = NPC;
                }
            });

            UpdateCommand = new DelegateCommand(UpdateNPC, CanUpdateNPC);
            NPCDetailsWindowCommand = new DelegateCommand<string>(OpenDetailsWindow);


            NPCAlignments = new List<string>{ "None", "Neutral", "Enemy", "Ally" };
            NPCTypes = new List<string>{ "Nemesis", "Adversary" };
            UpdatedNPC = false; UpdateNPCSucess = false;
        }

        private void OpenDetailsWindow(string windowToOpen)
        {
            switch (windowToOpen)
            {
                case "Skills":
                    if (NPC != null)
                    {
                        var navParams = new NavigationParameters();
                        navParams.Add("NPC", NPC);

                        _regionManager.RequestNavigate(NPCDetailsWindowName, "NPCSkillsView", navParams);
                    }
                    else
                    {
                        _regionManager.RequestNavigate(NPCDetailsWindowName, "NPCSkillsView");
                    }
                    break;
                default:
                    break;
            }
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
            {
                NPC = navigationContext.Parameters.GetValue<NPC>("NPC");
                AlliesAndEnemiesDBControl dbControl = new AlliesAndEnemiesDBControl();
                dbControl.GetDetailsForNPC(NPC);
            }

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
