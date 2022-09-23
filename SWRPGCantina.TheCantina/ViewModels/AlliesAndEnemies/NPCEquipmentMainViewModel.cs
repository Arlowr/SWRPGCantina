using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWRPGCantina.TheCantina.ViewModels
{
    public class NPCEquipmentMainViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator _eventAggregator;
        private bool Editing;
        public DelegateCommand AddCommand { get; private set; }
        public NPCEquipmentMainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            Editing = false;

            //AddCommand = new DelegateCommand(AddAbility, CanAddAbility);
        }

        //private bool CanAddAbility()
        //{
        //    if (EditingAbility == null || Editing == false)
        //        return false;
        //    if (string.IsNullOrEmpty(EditingAbility.Name) || string.IsNullOrEmpty(EditingAbility.Effect))
        //        return false;
        //    return true;
        //}

        //private void AddAbility()
        //{
        //    Ability tempAbility = new Ability();
        //    if (ThisNPC.Abilities.Any(x => x.tempID == EditingAbility.tempID))
        //    {
        //        tempAbility = ThisNPC.Abilities.FirstOrDefault(x => x.tempID == EditingAbility.tempID);
        //    }
        //    if (ThisNPC.Abilities.Any(x => x.DBID == EditingAbility.DBID) || EditingAbility.DBID != 0)
        //    {
        //        tempAbility = ThisNPC.Abilities.FirstOrDefault(x => x.DBID == EditingAbility.DBID);
        //    }
        //    ThisNPC.Abilities.Remove(tempAbility);
        //    EditingAbility.CharacterDbId = ThisNPC.DBID;
        //    ThisNPC.Abilities.Add(EditingAbility);
        //    _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(ThisNPC);

        //    UpdateAbilityList();

        //    EditingAbility = new Ability();
        //    Editing = false;
        //}

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
