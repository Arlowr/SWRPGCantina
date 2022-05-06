using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWRPGCantina.TheCantina.ViewModels.SkillsAndTalents
{
    public class TalentCreationViewModel : BindableBase, INavigationAware
    {

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

        public TalentCreationViewModel()
        {
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
                    UpdateTalentText = "Save Talent";
                } 
                else if (DisplayType == "Update")
                {
                    ForCharacter = false;
                    UpdateTalentText = "Update Talent";
                } 
                else if (DisplayType == "CharacterStyle")
                {
                    ForCharacter = true;
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
