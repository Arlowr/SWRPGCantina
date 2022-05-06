using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Database;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWRPGCantina.TheCantina.ViewModels.SkillsAndTalents
{
    public class TalentsViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private List<Talent> _talentsList;
        public List<Talent> TalentsList
        {
            get { return _talentsList; }
            set { SetProperty(ref _talentsList, value); }
        }
        private Talent _selectedTalent;
        public Talent SelectedTalent
        {
            get { return _selectedTalent; }
            set 
            { 
                SetProperty(ref _selectedTalent, value);
                DisplayTalent = new Talent
                {
                    DbId = SelectedTalent.DbId,
                    Name = SelectedTalent.Name,
                    Description = SelectedTalent.Description,
                    StatIncrease = SelectedTalent.StatIncrease,
                    StatIncreaseName = SelectedTalent.StatIncreaseName, 
                    IsActiveTalent = SelectedTalent.IsActiveTalent,
                    IsForceTalent = SelectedTalent.IsForceTalent
                };
            }
        }

        private Talent _displayTalent;
        public Talent DisplayTalent
        {
            get { return _displayTalent; }
            set { SetProperty(ref _displayTalent, value); }
        }
        public DelegateCommand NewTalentCommand { get; private set; }
        public DelegateCommand UpdateTalentCommand { get; private set; }
        public TalentsViewModel(IRegionManager regionManger)
        {
            _regionManager = regionManger;

            NewTalentCommand = new DelegateCommand(NewTalentCommandHandler);
            UpdateTalentCommand = new DelegateCommand(UpdateTalentCommandHandler);


            SkillsAndTalentsDBControl dbControl = new SkillsAndTalentsDBControl();
            TalentsList = dbControl.GetListOfTalents();
        }

        private void UpdateTalentCommandHandler()
        {
            UpdateTalentScreen(SelectedTalent, "Update");
        }

        private void NewTalentCommandHandler()
        {
            UpdateTalentScreen(new Talent(), "New");
        }

        private void UpdateTalentScreen(Talent talent, string displayType)
        {
            var navParams = new NavigationParameters();
            navParams.Add("Talent", talent);
            navParams.Add("DisplayType", displayType);

            _regionManager.RequestNavigate("TalentUpdateRegion", "TalentCreationView", navParams);

        }
    }
}
