using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Database;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static SWRPGCantina.Core.Models.Talent;

namespace SWRPGCantina.TheCantina.ViewModels.SkillsAndTalents
{
    public class TalentCreationViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator _eventAggregator;
        private string _updateTalentText;
        public string UpdateTalentText
        {
            get { return _updateTalentText; }
            set { SetProperty(ref _updateTalentText, value); }
        }

        private bool _forCharacter;
        public bool ForCharacter
        {
            get { return _forCharacter; }
            set { SetProperty(ref _forCharacter, value); }
        }

        private bool _needsRank;
        public bool NeedsRank
        {
            get { return _needsRank; }
            set { SetProperty(ref _needsRank, value); }
        }

        private Talent _editingTalent;
        public Talent EditingTalent
        {
            get { return _editingTalent; }
            set { SetProperty(ref _editingTalent, value); }
        }

        private List<string> _possibleStatIncreaseList;
        public List<string> PossibleStatIncreaseList
        {
            get { return _possibleStatIncreaseList; }
            set { SetProperty(ref _possibleStatIncreaseList, value); }
        }

        private List<int> _rankList;
        public List<int> RankList
        {
            get { return _rankList; }
            set { SetProperty(ref _rankList, value); }
        }

        public DelegateCommand UpdateTalentCommand { get; private set; }
        public TalentCreationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            UpdateTalentText = "Update Talent";

            UpdateTalentCommand = new DelegateCommand(UpdateTalentCommandHandler);

            PossibleStatIncreaseList = new List<string> { "None", "Soak", "Strain", "Wounds" };
            RankList = new List<int> { 1, 2, 3, 4, 5 };
        }

        private void UpdateTalentCommandHandler()
        {
            SkillsAndTalentsDBControl DbControl = new SkillsAndTalentsDBControl();

            if (EditingTalent.StatIncreaseName == "None")
                EditingTalent.StatIncrease = 0;

            DbControl.AddOrUpdateTalent(EditingTalent);

            _eventAggregator.GetEvent<TalentUpdatedEvent>().Publish(_editingTalent);

            UpdateTalentText = "Update Talent";
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Talent"))
            {
                EditingTalent = navigationContext.Parameters.GetValue<Talent>("Talent");
            }

            if (navigationContext.Parameters.ContainsKey("DisplayType"))
            {
                string DisplayType = navigationContext.Parameters.GetValue<string>("DisplayType");

                if(DisplayType == "New")
                {
                    ForCharacter = false;
                    NeedsRank = false;
                    UpdateTalentText = "Save Talent";
                } 
                else if (DisplayType == "Update")
                {
                    ForCharacter = false;
                    NeedsRank = false;
                    UpdateTalentText = "Update Talent";
                } 
                else if (DisplayType == "CharacterStyle")
                {
                    ForCharacter = true;
                    NeedsRank = true;
                    NeedsRank = EditingTalent.NeedsRanks;
                }
            }
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
