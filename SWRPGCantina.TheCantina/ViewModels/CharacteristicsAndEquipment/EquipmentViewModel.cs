using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
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
        private List<string> _characterEquipmentList;
        public List<string> CharacterEquipmentList
        {
            get { return _characterEquipmentList; }
            set { SetProperty(ref _characterEquipmentList, value); }
        }
        public DelegateCommand UpdateSelectedEquipmentCommand { get; private set; }
        public EquipmentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            AddUpdateEquipmentText = "Add New Equipment";

            UpdateSelectedEquipmentCommand = new DelegateCommand(PassEquipmentDetails);
        }

        private void PassEquipmentDetails()
        {
            throw new NotImplementedException();
        }

        private void UpdateEquipmentList()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
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
