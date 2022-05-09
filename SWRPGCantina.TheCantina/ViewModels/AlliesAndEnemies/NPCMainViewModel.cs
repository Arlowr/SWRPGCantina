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
    public class NPCMainViewModel: BindableBase, INavigationAware, INotifyPropertyChanged
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

        private List<int> _rarityRankings;
        public List<int> RarityRankings
        {
            get { return _rarityRankings; }
            set { SetProperty(ref _rarityRankings, value); }
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
        
        public NPCMainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<NPCUpdatedEvent>().Subscribe((NPC) =>
            {
                if (this.NPC.DBID == NPC.DBID)
                    if (!NPC.Name.ToUpper().Contains("NEW"))
                        this.NPC = NPC;
                    else if (NPC.Name.ToUpper().Contains("NEW") && (TabTitle == NPC.Name))
                        this.NPC = NPC;
            });

            UpdateCommand = new DelegateCommand(UpdateNPC, CanUpdateNPC);
            NPCDetailsWindowCommand = new DelegateCommand<string>(OpenDetailsWindow);


            NPCAlignments = new List<string>{ "None", "Neutral", "Enemy", "Ally" };
            NPCTypes = new List<string>{ "Nemesis", "Rival" };
            RarityRankings = new List<int> { 1,2,3,4,5,6,7,8,9,10};
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
                case "Talents":
                    if (NPC != null)
                    {
                        var navParams = new NavigationParameters();
                        navParams.Add("NPC", NPC);

                        _regionManager.RequestNavigate(NPCDetailsWindowName, "NPCTalentsView", navParams);
                    }
                    else
                    {
                        _regionManager.RequestNavigate(NPCDetailsWindowName, "NPCTalentsView");
                    }
                    break;
                case "Abilities":
                    if (NPC != null)
                    {
                        var navParams = new NavigationParameters();
                        navParams.Add("NPC", NPC);

                        _regionManager.RequestNavigate(NPCDetailsWindowName, "NPCAbilitiesMainView", navParams);
                    }
                    else
                    {
                        _regionManager.RequestNavigate(NPCDetailsWindowName, "NPCAbilitiesMainView");
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

            TabTitle = NPC.Name;

            UpdatedNPC = true;

            _eventAggregator.GetEvent<NPCDBUpdatedEvent>().Publish();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("NPC"))
            {
                NPC = navigationContext.Parameters.GetValue<NPC>("NPC");
                AlliesAndEnemiesDBControl dbControl = new AlliesAndEnemiesDBControl();
                TabTitle = NPC.Name;
                NPCDetailsWindowName = NPC.Name.Replace(" ", "") + "DetailsWindow";

                if (!NPC.Name.Contains("New"))
                    dbControl.GetDetailsForNPC(NPC);
                else
                {
                    SetUpNPCSkills();
                    NPC.NPCType = "Nemesis";
                    NPC.RarityRank = 5;
                }
            }

        }

        private void SetUpNPCSkills()
        {
            NPC.Astrogation = new Skill { Name = "Astrogation", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Athletics = new Skill { Name = "Athletics", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Charm = new Skill { Name = "Charm", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Coercion = new Skill { Name = "Coercion", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Computers = new Skill { Name = "Computers", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Cool = new Skill { Name = "Cool", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Coordination = new Skill { Name = "Coordination", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Deception = new Skill { Name = "Deception", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Discipline = new Skill { Name = "Discipline", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Leadership = new Skill { Name = "Leadership", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Mechanics = new Skill { Name = "Mechanics", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Medicine = new Skill { Name = "Medicine", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Negotiation = new Skill { Name = "Negotiation", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Perception = new Skill { Name = "Perception", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.PilotingPlanetary = new Skill { Name = "PilotingPlanetary", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.PilotingSpace = new Skill { Name = "PilotingSpace", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Resilience = new Skill { Name = "Resilience", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Skullduggery = new Skill { Name = "Skullduggery", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Stealth = new Skill { Name = "Stealth", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Streetwise = new Skill { Name = "Streetwise", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Survival = new Skill { Name = "Survival", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Vigilance = new Skill { Name = "Vigilance", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            NPC.Brawl = new Skill { Name = "Brawl", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            NPC.Gunnery = new Skill { Name = "Gunnery", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            NPC.Lightsaber = new Skill { Name = "Lightsaber", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            NPC.Melee = new Skill { Name = "Melee", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            NPC.RangedLight = new Skill { Name = "RangedLight", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            NPC.RangedHeavy = new Skill { Name = "RangedHeavy", Rank = 0, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            NPC.CoreWorldKnow = new Skill { Name = "CoreWorldKnow", Rank = 0, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            NPC.EducationKnow = new Skill { Name = "EducationKnow", Rank = 0, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            NPC.LoreKnow = new Skill { Name = "LoreKnow", Rank = 0, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            NPC.OuterRimKnow = new Skill { Name = "OuterRimKnow", Rank = 0, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            NPC.UnderworldKnow = new Skill { Name = "UnderworldKnow", Rank = 0, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            NPC.WarfareKnow = new Skill { Name = "WarfareKnow", Rank = 0, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            NPC.XenologyKnow = new Skill { Name = "XenologyKnow", Rank = 0, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
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
