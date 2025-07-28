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

        private string _addUpdateEquipmentText;
        public string AddUpdateEquipmentText
        {
            get { return _addUpdateEquipmentText; }
            set { SetProperty(ref _addUpdateEquipmentText, value); }
        }

        private string _currentEquipment;
        public string CurrentEquipment
        {
            get { return _currentEquipment; }
            set { SetProperty(ref _currentEquipment, value); }
        }

        private Equipment _selectedEquipment;
        public Equipment SelectedEquipment
        {
            get { return _selectedEquipment; }
            set { SetProperty(ref _selectedEquipment, value); }
        }
        private List<Equipment> _equipmentList;
        public List<Equipment> EquipmentList
        {
            get { return _equipmentList; }
            set { SetProperty(ref _equipmentList, value); }
        }
        public DelegateCommand UpdateSelectedEquipmentCommand { get; private set; }
        public EquipmentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            AddUpdateEquipmentText = "Add New Equipment";

            UpdateSelectedEquipmentCommand = new DelegateCommand(PassEquipmentDetails);

            CharacteristicsAndEquipmentDBControl dbControl = new CharacteristicsAndEquipmentDBControl();
            EquipmentList = dbControl.GetListOfEquipment();
        }

        private void PassEquipmentDetails()
        {
            throw new NotImplementedException();
        }

        private void UpdateEquipmentList()
        {
            List<Equipment> tempList = new List<Equipment>();

            foreach (var equipment in EquipmentList)
            {
                tempList.Add(equipment);
            }

            EquipmentList = new List<Equipment>();

            foreach (var equipment in tempList)
            {
                EquipmentList.Add(equipment);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateEquipmentList();
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
