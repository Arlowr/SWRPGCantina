using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Database;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWRPGCantina.TheCantina.ViewModels
{
    public class EquipmentViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator _eventAggregator;

        private string _addUpdateGearText;
        public string AddUpdateGearText
        {
            get { return _addUpdateGearText; }
            set { SetProperty(ref _addUpdateGearText, value); }
        }

        private string _currentGear;
        public string CurrentGear
        {
            get { return _currentGear; }
            set { SetProperty(ref _currentGear, value); }
        }

        private Equipment _selectedGear;
        public Equipment SelectedGear
        {
            get { return _selectedGear; }
            set { SetProperty(ref _selectedGear, value); }
        }
        private List<Gear> _gearList;
        public List<Gear> GearList
        {
            get { return _gearList; }
            set { SetProperty(ref _gearList, value); }
        }
        public DelegateCommand UpdateSelectedGearCommand { get; private set; }
        public EquipmentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            AddUpdateGearText = "Add New Equipment";

            UpdateSelectedGearCommand = new DelegateCommand(PassGearDetails);

            CharacteristicsAndEquipmentDBControl dbControl = new CharacteristicsAndEquipmentDBControl();
            GearList = dbControl.GetListOfGear();
        }

        private void PassGearDetails()
        {
            throw new NotImplementedException();
        }

        private void UpdateGearList()
        {
            List<Gear> tempList = new List<Gear>();

            foreach (var gear in GearList)
            {
                tempList.Add(gear);
            }

            GearList = new List<Gear>();

            foreach (var gear in tempList)
            {
                GearList.Add(gear);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateGearList();
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
