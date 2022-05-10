using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static SWRPGCantina.Core.Models.NPC;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCAbilitiesMainViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator _eventAggregator;
        private bool _editing;
        public bool Editing
        {
            get { return _editing; }
            set { SetProperty(ref _editing, value); }
        }

        private Ability _editingAbility;
        public Ability EditingAbility
        {
            get { return _editingAbility; }
            set 
            { 
                SetProperty(ref _editingAbility, value);
                AbilityName = EditingAbility.Name;
                EffectText = EditingAbility.Effect;
                WhenText = EditingAbility.When;
            }
        }
        private string _abilityName;
        public string AbilityName
        {
            get { return _abilityName; }
            set
            {
                SetProperty(ref _abilityName, value);
                EditingAbility.Name = AbilityName;
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        private string _whenText;
        public string WhenText
        {
            get { return _whenText; }
            set
            {
                SetProperty(ref _whenText, value);
                EditingAbility.When = WhenText;
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        private string _effectText;
        public string EffectText
        {
            get { return _effectText; }
            set 
            { 
                SetProperty(ref _effectText, value);
                EditingAbility.Effect = EffectText;
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        private List<Ability> _characterAbilityList;
        public List<Ability> CharacterAbilityList
        {
            get { return _characterAbilityList; }
            set { SetProperty(ref _characterAbilityList, value); }
        }

        private Ability _selectedCharacterAbility;
        public Ability SelectedCharacterAbility
        {
            get { return _selectedCharacterAbility; }
            set { SetProperty(ref _selectedCharacterAbility, value); }
        }

        private NPC _thisNPC;
        public NPC ThisNPC
        {
            get { return _thisNPC; }
            set { SetProperty(ref _thisNPC, value); }
        }

        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand NewAbilityCommand { get; private set; }
        public DelegateCommand RemoveAbilityCommand { get; private set; }
        public NPCAbilitiesMainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            Editing = false;

            NewAbilityCommand = new DelegateCommand(NewAbility);
            AddCommand = new DelegateCommand(AddAbility, CanAddAbility);
            UpdateCommand = new DelegateCommand(UpdateAbility);
            RemoveAbilityCommand = new DelegateCommand(RemoveAbility);
        }

        private bool CanAddAbility()
        {
            if(EditingAbility == null || Editing == false)
                return false;
            if (string.IsNullOrEmpty(EditingAbility.Name) || string.IsNullOrEmpty(EditingAbility.Effect))
                return false;
            return true;
        }

        private void AddAbility()
        {
            Ability tempAbility = new Ability();
            if(ThisNPC.Abilities.Any(x => x.tempID == EditingAbility.tempID) )
            {
                tempAbility = ThisNPC.Abilities.FirstOrDefault(x => x.tempID == EditingAbility.tempID);
            }
            if(ThisNPC.Abilities.Any(x => x.DBID == EditingAbility.DBID) || EditingAbility.DBID != 0)
            {
                tempAbility = ThisNPC.Abilities.FirstOrDefault(x => x.DBID == EditingAbility.DBID);
            }
            ThisNPC.Abilities.Remove(tempAbility);
            EditingAbility.CharacterDbId = ThisNPC.DBID;
            ThisNPC.Abilities.Add(EditingAbility);
            _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(ThisNPC);

            UpdateAbilityList();

            EditingAbility = new Ability();
            Editing = false;
        }

        private void UpdateAbility()
        {
            EditingAbility = SelectedCharacterAbility;
            AbilityName = EditingAbility.Name;
            EffectText = EditingAbility.Effect;
            WhenText = EditingAbility.When;
            Editing = true;
        }

        private void NewAbility()
        {
            EditingAbility = new Ability();
            EditingAbility.tempID = ThisNPC.Abilities.Count() + 1;
            Editing = true;
        }

        private void UpdateAbilityList()
        {
            CharacterAbilityList = new List<Ability>();
            List<Ability> tempList = new List<Ability>();

            foreach (var ability in ThisNPC.Abilities)
            {
                tempList.Add(ability);
            }
            CharacterAbilityList = tempList;
        }

        private void RemoveAbility()
        {
            Ability tempAbility = new Ability();
            if (ThisNPC.Abilities.Any(x => x.tempID == SelectedCharacterAbility.tempID))
            {
                tempAbility = ThisNPC.Abilities.FirstOrDefault(x => x.tempID == SelectedCharacterAbility.tempID);
            }
            if (ThisNPC.Abilities.Any(x => x.DBID == SelectedCharacterAbility.DBID))
            {
                tempAbility = ThisNPC.Abilities.FirstOrDefault(x => x.DBID == SelectedCharacterAbility.DBID);
            }
            ThisNPC.Abilities.Remove(tempAbility);
            _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(ThisNPC);

            UpdateAbilityList();

            EditingAbility = new Ability();
            Editing = false;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("NPC"))
                ThisNPC = navigationContext.Parameters.GetValue<NPC>("NPC");

            if (ThisNPC.Abilities == null)
            {
                CharacterAbilityList = new List<Ability>();
                ThisNPC.Abilities = new List<Ability>();
            }
            else
                UpdateAbilityList();

            Editing = false;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
