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

namespace SWRPGCantina.TheCantina.ViewModels.CharacteristicsAndEquipment
{
    public class TalentsViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        protected readonly IEventAggregator _eventAggregator;
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
            }
        }
        public DelegateCommand NewTalentCommand { get; private set; }
        public DelegateCommand UpdateTalentCommand { get; private set; }
        public TalentsViewModel(IRegionManager regionManger, IEventAggregator eventAggregator)
        {
            _regionManager = regionManger;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<TalentUpdatedEvent>().Subscribe((Talent) =>
            {
                if (!TalentsList.Any(x => x.DbId == Talent.DbId))
                {
                    TalentsList.Add(Talent);
                } 
                else
                {
                    foreach (var checkTalent in TalentsList)
                    {
                        if(checkTalent.DbId == Talent.DbId)
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
                UpdateTalentsList();
            });

            NewTalentCommand = new DelegateCommand(NewTalentCommandHandler);
            UpdateTalentCommand = new DelegateCommand(UpdateTalentCommandHandler);


            CharacteristicsAndEquipmentDBControl dbControl = new CharacteristicsAndEquipmentDBControl();
            TalentsList = dbControl.GetListOfTalents();
            
        }

        private void UpdateTalentsList()
        {
            List<Talent> tempList = new List<Talent>();

            foreach (var talent in TalentsList)
            {
                tempList.Add(talent);
            }

            TalentsList = new List<Talent>();

            foreach (var talent in tempList)
            {
                TalentsList.Add(talent);
            }
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
