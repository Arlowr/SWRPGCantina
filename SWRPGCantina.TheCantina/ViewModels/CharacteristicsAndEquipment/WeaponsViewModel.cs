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
    public class WeaponsViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator _eventAggregator;

        private string _addUpdateWeaponText;
        public string AddUpdateWeaponText
        {
            get { return _addUpdateWeaponText; }
            set { SetProperty(ref _addUpdateWeaponText, value); }
        }

        private string _currentWeapon;
        public string CurrentWeapon
        {
            get { return _currentWeapon; }
            set { SetProperty(ref _currentWeapon, value); }
        }

        private Equipment _selectedWeapon;
        public Equipment SelectedWeapon
        {
            get { return _selectedWeapon; }
            set { SetProperty(ref _selectedWeapon, value); }
        }
        private List<Weapon> _weaponList;
        public List<Weapon> WeaponList
        {
            get { return _weaponList; }
            set { SetProperty(ref _weaponList, value); }
        }
        public DelegateCommand UpdateSelectedWeaponCommand { get; private set; }
        public WeaponsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            AddUpdateWeaponText = "Add New Weapon";

            UpdateSelectedWeaponCommand = new DelegateCommand(PassWeaponDetails);

            CharacteristicsAndEquipmentDBControl dbControl = new CharacteristicsAndEquipmentDBControl();
            var WeaponList = dbControl.GetListOfWeapons();
        }

        private void PassWeaponDetails()
        {
            throw new NotImplementedException();
        }

        private void UpdateWeaponList()
        {
            List<Weapon> tempList = new List<Weapon>();

            foreach (var weapon in WeaponList)
            {
                tempList.Add(weapon);
            }

            WeaponList = new List<Weapon>();

            foreach (var weapon in tempList)
            {
                WeaponList.Add(weapon);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateWeaponList();
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