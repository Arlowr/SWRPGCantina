using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static SWRPGCantina.Core.Models.NPC;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCMinionSkillsViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        protected readonly IEventAggregator _eventAggregator;

        private NPC _NPC;
        public NPC NPC
        {
            get { return _NPC; }
            set
            {
                SetProperty(ref _NPC, value);
            }
        }

        #region SkillBools

        private bool _astrogation;
        public bool Astrogation
        {
            get { return _astrogation; }
            set
            {
                SetProperty(ref _astrogation, value);
                if (Astrogation == true)
                    NPC.Astrogation.Rank = 1;
                else
                    NPC.Astrogation.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _athletics;
        public bool Athletics
        {
            get { return _athletics; }
            set
            {
                SetProperty(ref _athletics, value);
                if (Athletics == true)
                    NPC.Athletics.Rank = 1;
                else
                    NPC.Athletics.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _charm;
        public bool Charm
        {
            get { return _charm; }
            set
            {
                SetProperty(ref _charm, value);
                if (Charm == true)
                    NPC.Charm.Rank = 1;
                else
                    NPC.Charm.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _coercion;
        public bool Coercion
        {
            get { return _coercion; }
            set
            {
                SetProperty(ref _coercion, value);
                if (Coercion == true)
                    NPC.Coercion.Rank = 1;
                else
                    NPC.Coercion.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _computers;
        public bool Computers
        {
            get { return _computers; }
            set
            {
                SetProperty(ref _computers, value);
                if (Computers == true)
                    NPC.Computers.Rank = 1;
                else
                    NPC.Computers.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _cool;
        public bool Cool
        {
            get { return _cool; }
            set
            {
                SetProperty(ref _cool, value);
                if (Cool == true)
                    NPC.Cool.Rank = 1;
                else
                    NPC.Cool.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _coordination;
        public bool Coordination
        {
            get { return _coordination; }
            set
            {
                SetProperty(ref _coordination, value);
                if (Coordination == true)
                    NPC.Coordination.Rank = 1;
                else
                    NPC.Coordination.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _deception;
        public bool Deception
        {
            get { return _deception; }
            set
            {
                SetProperty(ref _deception, value);
                if (Deception == true)
                    NPC.Deception.Rank = 1;
                else
                    NPC.Deception.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _discipline;
        public bool Discipline
        {
            get { return _discipline; }
            set
            {
                SetProperty(ref _discipline, value);
                if (Discipline == true)
                    NPC.Discipline.Rank = 1;
                else
                    NPC.Discipline.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _leadership;
        public bool Leadership
        {
            get { return _leadership; }
            set
            {
                SetProperty(ref _leadership, value);
                if (Leadership == true)
                    NPC.Leadership.Rank = 1;
                else
                    NPC.Leadership.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _mechanics;
        public bool Mechanics
        {
            get { return _mechanics; }
            set
            {
                SetProperty(ref _mechanics, value);
                if (Mechanics == true)
                    NPC.Mechanics.Rank = 1;
                else
                    NPC.Mechanics.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _medicine;
        public bool Medicine
        {
            get { return _medicine; }
            set
            {
                SetProperty(ref _medicine, value);
                if (Medicine == true)
                    NPC.Medicine.Rank = 1;
                else
                    NPC.Medicine.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _negotiation;
        public bool Negotiation
        {
            get { return _negotiation; }
            set
            {
                SetProperty(ref _negotiation, value);
                if (Negotiation == true)
                    NPC.Negotiation.Rank = 1;
                else
                    NPC.Negotiation.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _perception;
        public bool Perception
        {
            get { return _perception; }
            set
            {
                SetProperty(ref _perception, value);
                if (Perception == true)
                    NPC.Perception.Rank = 1;
                else
                    NPC.Perception.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _pilotingP;
        public bool PilotingP
        {
            get { return _pilotingP; }
            set
            {
                SetProperty(ref _pilotingP, value);
                if (PilotingP == true)
                    NPC.PilotingPlanetary.Rank = 1;
                else
                    NPC.PilotingPlanetary.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _pilotingS;
        public bool PilotingS
        {
            get { return _pilotingS; }
            set
            {
                SetProperty(ref _pilotingS, value);
                if (PilotingS == true)
                    NPC.PilotingSpace.Rank = 1;
                else
                    NPC.PilotingSpace.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _resiliance;
        public bool Resilience
        {
            get { return _resiliance; }
            set
            {
                SetProperty(ref _resiliance, value);
                if (Resilience == true)
                    NPC.Resilience.Rank = 1;
                else
                    NPC.Resilience.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _skullduggery;
        public bool Skullduggery
        {
            get { return _skullduggery; }
            set
            {
                SetProperty(ref _skullduggery, value);
                if (Skullduggery == true)
                    NPC.Skullduggery.Rank = 1;
                else
                    NPC.Skullduggery.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _stealth;
        public bool Stealth
        {
            get { return _stealth; }
            set
            {
                SetProperty(ref _stealth, value);
                if (Stealth == true)
                    NPC.Stealth.Rank = 1;
                else
                    NPC.Stealth.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _streetwise;
        public bool Streetwise
        {
            get { return _streetwise; }
            set
            {
                SetProperty(ref _streetwise, value);
                if (Streetwise == true)
                    NPC.Streetwise.Rank = 1;
                else
                    NPC.Streetwise.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _survival;
        public bool Survival
        {
            get { return _survival; }
            set
            {
                SetProperty(ref _survival, value);
                if (Survival == true)
                    NPC.Survival.Rank = 1;
                else
                    NPC.Survival.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _vigilance;
        public bool Vigilance
        {
            get { return _vigilance; }
            set
            {
                SetProperty(ref _vigilance, value);
                if (Vigilance == true)
                    NPC.Vigilance.Rank = 1;
                else
                    NPC.Vigilance.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _brawl;
        public bool Brawl
        {
            get { return _brawl; }
            set
            {
                SetProperty(ref _brawl, value);
                if (Brawl == true)
                    NPC.Brawl.Rank = 1;
                else
                    NPC.Brawl.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _gunnery;
        public bool Gunnery
        {
            get { return _gunnery; }
            set
            {
                SetProperty(ref _gunnery, value);
                if (Gunnery == true)
                    NPC.Gunnery.Rank = 1;
                else
                    NPC.Gunnery.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _melee;
        public bool Melee
        {
            get { return _melee; }
            set
            {
                SetProperty(ref _melee, value);
                if (Melee == true)
                    NPC.Melee.Rank = 1;
                else
                    NPC.Melee.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _rangedL;
        public bool RangedL
        {
            get { return _rangedL; }
            set
            {
                SetProperty(ref _rangedL, value);
                if (RangedL == true)
                    NPC.RangedLight.Rank = 1;
                else
                    NPC.RangedLight.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _rangedH;
        public bool RangedH
        {
            get { return _rangedH; }
            set
            {
                SetProperty(ref _rangedH, value);
                if (RangedH == true)
                    NPC.RangedHeavy.Rank = 1;
                else
                    NPC.RangedHeavy.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _lightsaber;
        public bool Lightsaber
        {
            get { return _lightsaber; }
            set
            {
                SetProperty(ref _lightsaber, value);
                if (Lightsaber == true)
                    NPC.Lightsaber.Rank = 1;
                else
                    NPC.Lightsaber.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _coreWorld;
        public bool CoreWorld
        {
            get { return _coreWorld; }
            set
            {
                SetProperty(ref _coreWorld, value);
                if (CoreWorld == true)
                    NPC.CoreWorldKnow.Rank = 1;
                else
                    NPC.CoreWorldKnow.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _education;
        public bool Education
        {
            get { return _education; }
            set
            {
                SetProperty(ref _education, value);
                if (Education == true)
                    NPC.EducationKnow.Rank = 1;
                else
                    NPC.EducationKnow.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _lore;
        public bool Lore
        {
            get { return _lore; }
            set
            {
                SetProperty(ref _lore, value);
                if (Lore == true)
                    NPC.LoreKnow.Rank = 1;
                else
                    NPC.LoreKnow.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _outerRim;
        public bool OuterRim
        {
            get { return _outerRim; }
            set
            {
                SetProperty(ref _outerRim, value);
                if (OuterRim == true)
                    NPC.OuterRimKnow.Rank = 1;
                else
                    NPC.OuterRimKnow.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _underworld;
        public bool Underworld
        {
            get { return _underworld; }
            set
            {
                SetProperty(ref _underworld, value);
                if (Underworld == true)
                    NPC.UnderworldKnow.Rank = 1;
                else
                    NPC.UnderworldKnow.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _warfareKnow;
        public bool WarfareKnow
        {
            get { return _warfareKnow; }
            set
            {
                SetProperty(ref _warfareKnow, value);
                if (WarfareKnow == true)
                    NPC.WarfareKnow.Rank = 1;
                else
                    NPC.WarfareKnow.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }

        private bool _xenoKnow;
        public bool XenoKnow
        {
            get { return _xenoKnow; }
            set
            {
                SetProperty(ref _xenoKnow, value);
                if (XenoKnow == true)
                    NPC.XenologyKnow.Rank = 1;
                else
                    NPC.XenologyKnow.Rank = 0;
                _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
            }
        }


        #endregion

        public NPCMinionSkillsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("NPC"))
                NPC = navigationContext.Parameters.GetValue<NPC>("NPC");

            SetUpSkills();

            var navParams = new NavigationParameters();
            navParams.Add("NPC", NPC);
            _regionManager.RequestNavigate("NPCTalentsRegion", "NPCTalentsView", navParams);
        }

        private void SetUpSkills()
        {
            if (NPC.Astrogation.Rank == 1)
                Astrogation = true;
            if (NPC.Athletics.Rank == 1)
                Athletics = true;
            if (NPC.Charm.Rank == 1)
                Charm = true;
            if (NPC.Coercion.Rank == 1)
                Coercion = true;
            if (NPC.Computers.Rank == 1)
                Computers = true;
            if (NPC.Cool.Rank == 1)
                Cool = true;
            if (NPC.Coordination.Rank == 1)
                Coordination = true;
            if (NPC.Deception.Rank == 1)
                Deception = true;
            if (NPC.Discipline.Rank == 1)
                Discipline = true;
            if (NPC.Leadership.Rank == 1)
                Leadership = true;
            if (NPC.Mechanics.Rank == 1)
                Mechanics = true;
            if (NPC.Medicine.Rank == 1)
                Medicine = true;
            if (NPC.Negotiation.Rank == 1)
                Negotiation = true;
            if (NPC.Perception.Rank == 1)
                Perception = true;
            if (NPC.PilotingPlanetary.Rank == 1)
                PilotingP = true;
            if (NPC.PilotingSpace.Rank == 1)
                PilotingS = true;
            if (NPC.Resilience.Rank == 1)
                Resilience = true;
            if (NPC.Skullduggery.Rank == 1)
                Skullduggery = true;
            if (NPC.Stealth.Rank == 1)
                Stealth = true;
            if (NPC.Streetwise.Rank == 1)
                Streetwise = true;
            if (NPC.Survival.Rank == 1)
                Survival = true;
            if (NPC.Vigilance.Rank == 1)
                Vigilance = true;
            if (NPC.Brawl.Rank == 1)
                Brawl = true;
            if (NPC.Gunnery.Rank == 1)
                Gunnery = true;
            if (NPC.Melee.Rank == 1)
                Melee = true;
            if (NPC.RangedLight.Rank == 1)
                RangedL = true;
            if (NPC.RangedHeavy.Rank == 1)
                RangedH = true;
            if (NPC.Lightsaber.Rank == 1)
                Lightsaber = true;
            if (NPC.CoreWorldKnow.Rank == 1)
                CoreWorld = true;
            if (NPC.EducationKnow.Rank == 1)
                Education = true;
            if (NPC.LoreKnow.Rank == 1)
                Lore = true;
            if (NPC.OuterRimKnow.Rank == 1)
                OuterRim = true;
            if (NPC.UnderworldKnow.Rank == 1)
                Underworld = true;
            if (NPC.WarfareKnow.Rank == 1)
                WarfareKnow = true;
            if (NPC.XenologyKnow.Rank == 1)
                XenoKnow = true;
        }
    }
}
