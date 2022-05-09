using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Database;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static SWRPGCantina.Core.Models.NPC;
using static SWRPGCantina.Core.Models.Talent;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCTalentsViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        protected readonly IEventAggregator _eventAggregator;

        private string _NPCTalentsWindowName;
        public string NPCTalentsWindowName
        {
            get { return _NPCTalentsWindowName; }
            set { SetProperty(ref _NPCTalentsWindowName, value); }
        }

        private List<Talent> _allTalentsList;
        public List<Talent> AllTalentsList
        {
            get { return _allTalentsList; }
            set { SetProperty(ref _allTalentsList, value); }
        }
        private List<Talent> _unusedTalentsList;
        public List<Talent> UnusedTalentList
        {
            get { return _unusedTalentsList; }
            set { SetProperty(ref _unusedTalentsList, value); }
        }
        private Talent _selectedTalent;
        public Talent SelectedTalent
        {
            get { return _selectedTalent; }
            set
            {
                if (value != null)
                    if (value.DbId == 0)
                        value.DbId = AllTalentsList.FirstOrDefault(x => x.Name == value.Name).DbId;

                SetProperty(ref _selectedTalent, value);
                UpdateTalentCommand.RaiseCanExecuteChanged();
                AddTalentCommand.RaiseCanExecuteChanged();
            }
        }
        private Talent _currentlyEditing;
        public Talent CurrentlyEditing
        {
            get { return _currentlyEditing; }
            set { SetProperty(ref _currentlyEditing, value); }
        }
        private List<Talent> _characterTalentList;
        public List<Talent> CharacterTalentList
        {
            get { return _characterTalentList; }
            set { SetProperty(ref _characterTalentList, value); }
        }
        private Talent _selectedCharacterTalent;
        public Talent SelectedCharacterTalent
        {
            get { return _selectedCharacterTalent; }
            set
            {
                if (value != null)
                    if (value.DbId == 0)
                        value.DbId = AllTalentsList.FirstOrDefault(x => x.Name == value.Name).DbId;

                SetProperty(ref _selectedCharacterTalent, value);
                RemoveCharacterTalentCommand.RaiseCanExecuteChanged();
                UpdateCharacterTalentCommand.RaiseCanExecuteChanged();
            }
        }

        private NPC _thisNPC;
        public NPC ThisNPC
        {
            get { return _thisNPC; }
            set { SetProperty(ref _thisNPC, value); }
        }

        public DelegateCommand NewTalentCommand { get; private set; }
        public DelegateCommand UpdateTalentCommand { get; private set; }
        public DelegateCommand AddTalentCommand { get; private set; }
        public DelegateCommand RemoveCharacterTalentCommand { get; private set; }
        public DelegateCommand UpdateCharacterTalentCommand { get; private set; }
        public NPCTalentsViewModel(IRegionManager regionManger, IEventAggregator eventAggregator)
        {
            _regionManager = regionManger;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<TalentUpdatedEvent>().Subscribe((Talent) =>
            {
                if (!AllTalentsList.Any(x => x.DbId == Talent.DbId))
                {
                    AllTalentsList.Add(Talent);
                }
                else
                {
                    foreach (var checkTalent in AllTalentsList)
                    {
                        if (checkTalent.DbId == Talent.DbId)
                        {
                            checkTalent.Name = Talent.Name;
                            checkTalent.Description = Talent.Description;
                            checkTalent.IsForceTalent = Talent.IsForceTalent;
                            checkTalent.IsActiveTalent = Talent.IsActiveTalent;
                            checkTalent.NeedsRanks = Talent.NeedsRanks;
                            checkTalent.StatIncrease = checkTalent.StatIncrease;
                            checkTalent.StatIncreaseName = checkTalent.StatIncreaseName;
                        }
                    }
                }
                UpdateTalentLists();

                if(Talent.CharacterDBInt != 0)
                {
                    ThisNPC.Talents.Remove(ThisNPC.Talents.FirstOrDefault(x => x.DbId == Talent.DbId));
                    ThisNPC.Talents.Add(Talent);
                    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(ThisNPC);
                }
            });

            NewTalentCommand = new DelegateCommand(NewTalentCommandHandler);
            UpdateTalentCommand = new DelegateCommand(UpdateTalentCommandHandler, CanUpdateSelectedTalent);
            AddTalentCommand = new DelegateCommand(AddTalentCommandHandler,CanAddTalentToCharacter);
            RemoveCharacterTalentCommand = new DelegateCommand(RemoveTalentCommandHandler, CanRemoveCharacterTalent);
            UpdateCharacterTalentCommand = new DelegateCommand(UpdateCharacterTalentCommandHandler, CanUpdateCharacterTalent);

            SkillsAndTalentsDBControl dbTalentControl = new SkillsAndTalentsDBControl();
            AllTalentsList = dbTalentControl.GetListOfTalents();
            UnusedTalentList = new List<Talent>();
            CharacterTalentList = new List<Talent>();

            UpdateTalentLists();
        }

        private bool CanUpdateCharacterTalent()
        {
            if (SelectedCharacterTalent != null)
                return true;
            return false;
        }
        private bool CanRemoveCharacterTalent()
        {
            if (SelectedCharacterTalent != null)
                return true;
            return false;
        }
        private bool CanAddTalentToCharacter()
        {
            if (SelectedTalent != null)
                return true;
            return false;
        }
        private bool CanUpdateSelectedTalent()
        {
            if (SelectedTalent != null)
                return true;
            return false;
        }

        private void UpdateTalentLists()
        {
            Thread.Sleep(10);
            UpdateCharacterTalentsList();
            UpdateUnusedTalentsList();
        }

        private void UpdateCharacterTalentsList()
        {
            List<Talent> tempList = new List<Talent>();

            if (ThisNPC != null)
            {
                foreach (var talent in ThisNPC.Talents)
                {
                    talent.CharacterDBInt = ThisNPC.DBID;
                    tempList.Add(talent);
                }
            }
            CharacterTalentList = new List<Talent>();
            CharacterTalentList = tempList;

            if (ThisNPC != null)
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_thisNPC);
        }

        private void UpdateUnusedTalentsList()
        {
            List<Talent> tempList = new List<Talent>();
            bool dontAdd = false;

            foreach (var talent in AllTalentsList)
            {
                dontAdd = false;

                if (ThisNPC != null)
                    if (ThisNPC.Talents.Any(x => x.Name == talent.Name))
                        dontAdd = true;

                if (dontAdd == false)
                {
                    talent.CharacterDBInt = 0;
                    tempList.Add(talent);
                }
            }
            UnusedTalentList = new List<Talent>();
            UnusedTalentList = tempList;
        }

        private void AddTalentCommandHandler()
        {
            ThisNPC.Talents.Add(SelectedTalent);
            CharacterTalentList.Add(SelectedTalent);

            if (SelectedTalent == CurrentlyEditing)
            {
                IRegion region = _regionManager.Regions[NPCTalentsWindowName];
                foreach (var view in region.ActiveViews)
                {
                    region.Remove(view);
                }
            }

            UpdateTalentLists();
        }

        private void RemoveTalentCommandHandler()
        {
            ThisNPC.Talents.Remove(SelectedCharacterTalent);
            CharacterTalentList.Remove(SelectedCharacterTalent);

            if (SelectedCharacterTalent == CurrentlyEditing)
            {
                IRegion region = _regionManager.Regions[NPCTalentsWindowName];
                foreach (var view in region.ActiveViews)
                {
                    region.Remove(view);
                }
            }

            UpdateTalentLists();
        }

        private void UpdateTalentCommandHandler()
        {
            UpdateTalentScreen(SelectedTalent, "Update");
        }

        private void NewTalentCommandHandler()
        {
            UpdateTalentScreen(new Talent(), "New");
        }

        private void UpdateCharacterTalentCommandHandler()
        {
            UpdateTalentScreen(SelectedCharacterTalent, "CharacterStyle");
        }

        private void UpdateTalentScreen(Talent talent, string displayType)
        {
            var navParams = new NavigationParameters();
            navParams.Add("Talent", talent);
            navParams.Add("DisplayType", displayType);

            NPCTalentsWindowName = ThisNPC.Name.Replace(" ", "") + "TalentsWindow";
            _regionManager.RequestNavigate(NPCTalentsWindowName, "TalentCreationView", navParams);

            CurrentlyEditing = talent;
        }

        private void ButtonsAvailable()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("NPC"))
                ThisNPC = navigationContext.Parameters.GetValue<NPC>("NPC");

            AlliesAndEnemiesDBControl dbNPCControl = new AlliesAndEnemiesDBControl();
            ThisNPC.Talents = dbNPCControl.GetNPCTalents(ThisNPC.DBID);

            UpdateTalentLists();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {   }
    }
}
