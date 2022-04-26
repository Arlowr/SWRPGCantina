﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Database;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCsMainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        #region Filters

        private bool _filtersEnabled;
        public bool FiltersEnabled
        {
            get { return _filtersEnabled; }
            set { SetProperty(ref _filtersEnabled, value); }
        }

        private List<string> _NPCAlignmentFilter;
        public List<string> NPCAlignmentFilter
        {
            get { return _NPCAlignmentFilter; }
            set { SetProperty(ref _NPCAlignmentFilter, value); }
        }

        private string _selectedAlignmentFilter;
        public string SelectedAlignmentFilter
        {
            get { return _selectedAlignmentFilter; }
            set
            {
                SetProperty(ref _selectedAlignmentFilter, value);
                FilterNPCs();
                CheckIfNeutral();
            }
        }

        private List<string> _NPCTypeFilter;
        public List<string> NPCTypeFilter
        {
            get { return _NPCTypeFilter; }
            set { SetProperty(ref _NPCTypeFilter, value); }
        }

        private string _selectedTypeFilter;
        public string SelectedTypeFilter
        {
            get { return _selectedTypeFilter; }
            set
            {
                SetProperty(ref _selectedTypeFilter, value);
                FilterNPCs();
            }
        }

        private bool _isNeutrals;
        public bool IsNeutrals
        {
            get { return _isNeutrals; }
            set { SetProperty(ref _isNeutrals, value); }
        }

        private void CheckIfNeutral()
        {
            if (SelectedAlignmentFilter == "Neutrals") { IsNeutrals = true; }
            else { IsNeutrals = false; }
        }

        #endregion

        private List<NPC> _listedNPCs;
        public List<NPC> ListedNPCs
        {
            get { return _listedNPCs; }
            set { SetProperty(ref _listedNPCs, value); }
        }
        private List<NPC> _allNPCs;
        public List<NPC> AllNPCs
        {
            get { return _allNPCs; }
            set { SetProperty(ref _allNPCs, value); }
        }

        private NPC _selectedNPC;
        public NPC SelectedNPC
        {
            get { return _selectedNPC; }
            set 
            { 
                SetProperty(ref _selectedNPC, value);
                if (SelectedNPC != null)
                    SelectNPCCommand.RaiseCanExecuteChanged();
            }
        }

        private string _searchFilter;
        public string SearchFilter
        {
            get { return _searchFilter; }
            set 
            { 
                SetProperty(ref _searchFilter, value);
                FilterNPCs();
            }
        }

        public DelegateCommand SelectNPCCommand { get; private set; }
        public DelegateCommand ResetSearchCommand { get; private set; }
        public DelegateCommand NewNPCCommand { get; private set; }

        public NPCsMainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            AlliesAndEnemiesDBControl dbConnection = new AlliesAndEnemiesDBControl();
            AllNPCs = dbConnection.GetListOfNPCs();

            FiltersEnabled = true;
            SetFilterLists();
            ResetSearch();

            SelectNPCCommand = new DelegateCommand(SelectNPC, CanSelectNPC);
            NewNPCCommand = new DelegateCommand(CreateNewNPC);
            ResetSearchCommand = new DelegateCommand(ResetSearch);
        }

        private void SetFilterLists()
        {
            NPCAlignmentFilter = new List<string> { "All", "Neutrals", "Enemies", "Allies" };
            SelectedAlignmentFilter = "All";

            NPCTypeFilter = new List<string> { "All", "Nemeses", "Adversaries", "Minions" };
            SelectedTypeFilter = "All";
        }

        private void ResetSearch()
        {
            SearchFilter = "";
        }

        private bool CanSelectNPC()
        {
            if (SelectedNPC != null)
                return !string.IsNullOrEmpty(SelectedNPC.Name);
            else
                return false;
        }

        private void SelectNPC()
        {
            AddNewNPC("Selecting");
        }
        private void CreateNewNPC()
        {
            AddNewNPC("New");
        }

        private void AddNewNPC(string type)
        {
            if(type == "Selecting")
            {
                var navParams = new NavigationParameters();
                navParams.Add("NPC", SelectedNPC);

                _regionManager.RequestNavigate("NPCWindow", "NPCCharacterMainView", navParams);
            }
            else if (type == "New")
            {
                _regionManager.RequestNavigate("NPCWindow", "NPCCharacterMainView");
            }
        }

        private void FilterNPCs()
        {
            if (FiltersEnabled)
            {
                List<NPC> newList = new List<NPC>();
                ListedNPCs = new List<NPC>();

                foreach (NPC npc in AllNPCs)
                {
                    bool allowedToAdd = true;
                    if (SelectedAlignmentFilter != "All")
                    {
                        if (SelectedAlignmentFilter == "Enemies" && npc.NPCAlignment != "Enemy") { allowedToAdd = false; }
                        if (SelectedAlignmentFilter == "Neutrals" && npc.NPCAlignment != "Neutral") { allowedToAdd = false; }
                        if (SelectedAlignmentFilter == "Allies" && npc.NPCAlignment != "Ally") { allowedToAdd = false; }
                    }

                    if (SelectedTypeFilter != "All")
                    {
                        if (SelectedTypeFilter == "Nemeses" && npc.NPCAlignment != "Nemesis") { allowedToAdd = false; }
                        if (SelectedTypeFilter == "Adversaries" && npc.NPCAlignment != "Adversary") { allowedToAdd = false; }
                        if (SelectedTypeFilter == "Minions" && npc.NPCAlignment != "Minion") { allowedToAdd = false; }
                    }

                    if (!string.IsNullOrEmpty(SearchFilter))
                    {
                        if (!npc.Name.Contains(SearchFilter)) { allowedToAdd = false; }
                    }
                    
                    if (allowedToAdd)
                        newList.Add(npc);
                }


                ListedNPCs = newList;
            }
        }
    }
}
