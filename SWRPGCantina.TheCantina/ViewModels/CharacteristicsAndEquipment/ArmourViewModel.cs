using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Database;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.ViewModels.CharacteristicsAndEquipment
{
    class ArmourViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator _eventAggregator;

        private string _addUpdateArmourText;
        public string AddUpdateArmourText
        {
            get { return _addUpdateArmourText; }
            set { SetProperty(ref _addUpdateArmourText, value); }
        }

        private string _currentArmour;
        public string CurrentArmour
        {
            get { return _currentArmour; }
            set { SetProperty(ref _currentArmour, value); }
        }

        private Equipment _selectedArmour;
        public Equipment SelectedArmour
        {
            get { return _selectedArmour; }
            set { SetProperty(ref _selectedArmour, value); }
        }
        private List<Armour> _armourList;
        public List<Armour> ArmourList
        {
            get { return _armourList; }
            set { SetProperty(ref _armourList, value); }
        }
        public DelegateCommand UpdateSelectedArmourCommand { get; private set; }
        public ArmourViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            AddUpdateArmourText = "Add New Armour";

            UpdateSelectedArmourCommand = new DelegateCommand(PassArmourDetails);

            CharacteristicsAndEquipmentDBControl dbControl = new CharacteristicsAndEquipmentDBControl();
            var ArmourList = dbControl.GetListOfArmour();
        }

        private void PassArmourDetails()
        {
            throw new NotImplementedException();
        }

        private void UpdateArmourList()
        {
            List<Armour> tempList = new List<Armour>();

            foreach (var armour in ArmourList)
            {
                tempList.Add(armour);
            }

            ArmourList = new List<Armour>();

            foreach (var armour in tempList)
            {
                ArmourList.Add(armour);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateArmourList();
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
