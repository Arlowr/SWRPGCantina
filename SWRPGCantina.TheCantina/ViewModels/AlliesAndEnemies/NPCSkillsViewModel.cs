using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SWRPGCantina.Core.Models.NPC;

namespace SWRPGCantina.TheCantina.ViewModels.AlliesAndEnemies
{
    public class NPCSkillsViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator _eventAggregator;
        public event PropertyChangedEventHandler newPropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (newPropertyChanged != null)
            {
                newPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private NPC _NPC;
        public NPC NPC
        {
            get { return _NPC; }
            set 
            { 
                SetProperty(ref _NPC, value);
                SetDice("All");
            }
        }
        public DelegateCommand<string> ChangeSkillRankCommand { get; private set; }

        public NPCSkillsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<NPCUpdatedEvent>().Subscribe((NPC) =>
            {
                if (this.NPC.DBID == NPC.DBID)
                    if (!NPC.Name.ToUpper().Contains("NEW"))
                        this.NPC = NPC;
                    else if (NPC.Name.ToUpper().Contains("NEW") && (this.NPC.Name == NPC.Name))
                        this.NPC = NPC;
            });

            ChangeSkillRankCommand = new DelegateCommand<string>(ChangeSkillRank);

        }


        private void ChangeSkillRank(string whichCommand)
        {
            string whichSkill = whichCommand.Substring(0, whichCommand.Length - 5);
            string whichChange = whichCommand.Substring(whichCommand.Length - 5);

            int incdec = 1;
            if (whichChange == "Lower")
                incdec = -1;
            else
                incdec = 1;

            switch (whichSkill)
            {
                case "Astro":
                    NPC.Astrogation.Rank += incdec;
                    NPC.Astrogation.Rank = Math.Max(0, NPC.Astrogation.Rank);
                    NPC.Astrogation.Rank = Math.Min(5, NPC.Astrogation.Rank);
                    break;
                case "Athl":
                    NPC.Athletics.Rank += incdec;
                    NPC.Athletics.Rank = Math.Max(0, NPC.Athletics.Rank);
                    NPC.Athletics.Rank = Math.Min(5, NPC.Athletics.Rank);
                    break;
                case "Charm":
                    NPC.Charm.Rank += incdec;
                    NPC.Charm.Rank = Math.Max(0, NPC.Charm.Rank);
                    NPC.Charm.Rank = Math.Min(5, NPC.Charm.Rank);
                    break;
                case "Coercion":
                    NPC.Coercion.Rank += incdec;
                    NPC.Coercion.Rank = Math.Max(0, NPC.Coercion.Rank);
                    NPC.Coercion.Rank = Math.Min(5, NPC.Coercion.Rank);
                    break;
                case "Comp":
                    NPC.Computers.Rank += incdec;
                    NPC.Computers.Rank = Math.Max(0, NPC.Computers.Rank);
                    NPC.Computers.Rank = Math.Min(5, NPC.Computers.Rank);
                    break;
                case "Cool":
                    NPC.Cool.Rank += incdec;
                    NPC.Cool.Rank = Math.Max(0, NPC.Cool.Rank);
                    NPC.Cool.Rank = Math.Min(5, NPC.Cool.Rank);
                    break;
                case "Coord":
                    NPC.Coordination.Rank += incdec;
                    NPC.Coordination.Rank = Math.Max(0, NPC.Coordination.Rank);
                    NPC.Coordination.Rank = Math.Min(5, NPC.Coordination.Rank);
                    break;
                case "Decep":
                    NPC.Deception.Rank += incdec;
                    NPC.Deception.Rank = Math.Max(0, NPC.Deception.Rank);
                    NPC.Deception.Rank = Math.Min(5, NPC.Deception.Rank);
                    break;
                case "Disc":
                    NPC.Discipline.Rank += incdec;
                    NPC.Discipline.Rank = Math.Max(0, NPC.Discipline.Rank);
                    NPC.Discipline.Rank = Math.Min(5, NPC.Discipline.Rank);
                    break;
                case "Lead":
                    NPC.Leadership.Rank += incdec;
                    NPC.Leadership.Rank = Math.Max(0, NPC.Leadership.Rank);
                    NPC.Leadership.Rank = Math.Min(5, NPC.Leadership.Rank);
                    break;
                case "Mech":
                    NPC.Mechanics.Rank += incdec;
                    NPC.Mechanics.Rank = Math.Max(0, NPC.Mechanics.Rank);
                    NPC.Mechanics.Rank = Math.Min(5, NPC.Mechanics.Rank);
                    break;
                case "Med":
                    NPC.Medicine.Rank += incdec;
                    NPC.Medicine.Rank = Math.Max(0, NPC.Medicine.Rank);
                    NPC.Medicine.Rank = Math.Min(5, NPC.Medicine.Rank);
                    break;
                case "Nego":
                    NPC.Negotiation.Rank += incdec;
                    NPC.Negotiation.Rank = Math.Max(0, NPC.Negotiation.Rank);
                    NPC.Negotiation.Rank = Math.Min(5, NPC.Negotiation.Rank);
                    break;
                case "Percep":
                    NPC.Perception.Rank += incdec;
                    NPC.Perception.Rank = Math.Max(0, NPC.Perception.Rank);
                    NPC.Perception.Rank = Math.Min(5, NPC.Perception.Rank);
                    break;
                case "PilotingP":
                    NPC.PilotingPlanetary.Rank += incdec;
                    NPC.PilotingPlanetary.Rank = Math.Max(0, NPC.PilotingPlanetary.Rank);
                    NPC.PilotingPlanetary.Rank = Math.Min(5, NPC.PilotingPlanetary.Rank);
                    break;
                case "PilotingS":
                    NPC.PilotingSpace.Rank += incdec;
                    NPC.PilotingSpace.Rank = Math.Max(0, NPC.PilotingSpace.Rank);
                    NPC.PilotingSpace.Rank = Math.Min(5, NPC.PilotingSpace.Rank);
                    break;
                case "Resil":
                    NPC.Resilience.Rank += incdec;
                    NPC.Resilience.Rank = Math.Max(0, NPC.Resilience.Rank);
                    NPC.Resilience.Rank = Math.Min(5, NPC.Resilience.Rank);
                    break;
                case "Skul":
                    NPC.Skullduggery.Rank += incdec;
                    NPC.Skullduggery.Rank = Math.Max(0, NPC.Skullduggery.Rank);
                    NPC.Skullduggery.Rank = Math.Min(5, NPC.Skullduggery.Rank);
                    break;
                case "Stealth":
                    NPC.Stealth.Rank += incdec;
                    NPC.Stealth.Rank = Math.Max(0, NPC.Stealth.Rank);
                    NPC.Stealth.Rank = Math.Min(5, NPC.Stealth.Rank);
                    break;
                case "Street":
                    NPC.Streetwise.Rank += incdec;
                    NPC.Streetwise.Rank = Math.Max(0, NPC.Streetwise.Rank);
                    NPC.Streetwise.Rank = Math.Min(5, NPC.Streetwise.Rank);
                    break;
                case "Surv":
                    NPC.Survival.Rank += incdec;
                    NPC.Survival.Rank = Math.Max(0, NPC.Survival.Rank);
                    NPC.Survival.Rank = Math.Min(5, NPC.Survival.Rank);
                    break;
                case "Vigil":
                    NPC.Vigilance.Rank += incdec;
                    NPC.Vigilance.Rank = Math.Max(0, NPC.Vigilance.Rank);
                    NPC.Vigilance.Rank = Math.Min(5, NPC.Vigilance.Rank);
                    break;
                case "Brawl":
                    NPC.Brawl.Rank += incdec;
                    NPC.Brawl.Rank = Math.Max(0, NPC.Brawl.Rank);
                    NPC.Brawl.Rank = Math.Min(5, NPC.Brawl.Rank);
                    break;
                case "Gunnery":
                    NPC.Gunnery.Rank += incdec;
                    NPC.Gunnery.Rank = Math.Max(0, NPC.Gunnery.Rank);
                    NPC.Gunnery.Rank = Math.Min(5, NPC.Gunnery.Rank);
                    break;
                case "Melee":
                    NPC.Melee.Rank += incdec;
                    NPC.Melee.Rank = Math.Max(0, NPC.Melee.Rank);
                    NPC.Melee.Rank = Math.Min(5, NPC.Melee.Rank);
                    break;
                case "RangedL":
                    NPC.RangedLight.Rank += incdec;
                    NPC.RangedLight.Rank = Math.Max(0, NPC.RangedLight.Rank);
                    NPC.RangedLight.Rank = Math.Min(5, NPC.RangedLight.Rank);
                    break;
                case "RangedH":
                    NPC.RangedHeavy.Rank += incdec;
                    NPC.RangedHeavy.Rank = Math.Max(0, NPC.RangedHeavy.Rank);
                    NPC.RangedHeavy.Rank = Math.Min(5, NPC.RangedHeavy.Rank);
                    break;
                case "Lightsaber":
                    NPC.Lightsaber.Rank += incdec;
                    NPC.Lightsaber.Rank = Math.Max(0, NPC.Lightsaber.Rank);
                    NPC.Lightsaber.Rank = Math.Min(5, NPC.Lightsaber.Rank);
                    break;
                case "CoreKnow":
                    NPC.CoreWorldKnow.Rank += incdec;
                    NPC.CoreWorldKnow.Rank = Math.Max(0, NPC.CoreWorldKnow.Rank);
                    NPC.CoreWorldKnow.Rank = Math.Min(5, NPC.CoreWorldKnow.Rank);
                    break;
                case "EduKnow":
                    NPC.EducationKnow.Rank += incdec;
                    NPC.EducationKnow.Rank = Math.Max(0, NPC.EducationKnow.Rank);
                    NPC.EducationKnow.Rank = Math.Min(5, NPC.EducationKnow.Rank);
                    break;
                case "LoreKnow":
                    NPC.LoreKnow.Rank += incdec;
                    NPC.LoreKnow.Rank = Math.Max(0, NPC.LoreKnow.Rank);
                    NPC.LoreKnow.Rank = Math.Min(5, NPC.LoreKnow.Rank);
                    break;
                case "OuterKnow":
                    NPC.OuterRimKnow.Rank += incdec;
                    NPC.OuterRimKnow.Rank = Math.Max(0, NPC.OuterRimKnow.Rank);
                    NPC.OuterRimKnow.Rank = Math.Min(5, NPC.OuterRimKnow.Rank);
                    break;
                case "UnderKnow":
                    NPC.UnderworldKnow.Rank += incdec;
                    NPC.UnderworldKnow.Rank = Math.Max(0, NPC.UnderworldKnow.Rank);
                    NPC.UnderworldKnow.Rank = Math.Min(5, NPC.UnderworldKnow.Rank);
                    break;
                case "WarKnow":
                    NPC.WarfareKnow.Rank += incdec;
                    NPC.WarfareKnow.Rank = Math.Max(0, NPC.WarfareKnow.Rank);
                    NPC.WarfareKnow.Rank = Math.Min(5, NPC.WarfareKnow.Rank);
                    break;
                case "XenoKnow":
                    NPC.XenologyKnow.Rank += incdec;
                    NPC.XenologyKnow.Rank = Math.Max(0, NPC.XenologyKnow.Rank);
                    NPC.XenologyKnow.Rank = Math.Min(5, NPC.XenologyKnow.Rank);
                    break;
                default:
                    break;
            }
            SetDice(whichSkill);
            RaisePropertyChanged(nameof(NPC));

            _eventAggregator.GetEvent<NPCUpdatedEvent>().Publish(_NPC);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("NPC"))
                NPC = navigationContext.Parameters.GetValue<NPC>("NPC");

            SetDice("All");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
             
        }

        #region Dice Settings

        private void SetDice(string skill)
        {
            if (skill == "Astro" || skill == "All")
            {
                if (NPC.Astrogation.Rank >= 1)
                {
                    AstroProfVis = true;
                    AstroAbilityDice = Math.Max(NPC.Intellect, NPC.Astrogation.Rank);
                    AstroProfDice = Math.Min(NPC.Intellect, NPC.Astrogation.Rank);
                }
                else
                {
                    AstroProfVis = false;
                    AstroAbilityDice = NPC.Intellect;
                    AstroProfDice = 1;
                }
            }
            if (skill == "Athl" || skill == "All")
            {
                if (NPC.Athletics.Rank >= 1)
                {
                    AthlProfVis = true;
                    AthlAbilityDice = Math.Max(NPC.Brawn, NPC.Athletics.Rank);
                    AthlProfDice = Math.Min(NPC.Brawn, NPC.Athletics.Rank);
                }
                else
                {
                    AthlProfVis = false;
                    AthlAbilityDice = NPC.Brawn;
                    AthlProfDice = 1;
                }
            }
            if (skill == "Charm" || skill == "All")
            {
                if (NPC.Charm.Rank >= 1)
                {
                    CharmProfVis = true;
                    CharmAbilityDice = Math.Max(NPC.Presence, NPC.Charm.Rank);
                    CharmProfDice = Math.Min(NPC.Presence, NPC.Charm.Rank);
                }
                else
                {
                    CharmProfVis = false;
                    CharmAbilityDice = NPC.Presence;
                    CharmProfDice = 1;
                }
            }
            if (skill == "Coercion" || skill == "All")
            {
                if (NPC.Coercion.Rank >= 1)
                {
                    CoercionProfVis = true;
                    CoercionAbilityDice = Math.Max(NPC.Willpower, NPC.Coercion.Rank);
                    CoercionProfDice = Math.Min(NPC.Willpower, NPC.Coercion.Rank);
                }
                else
                {
                    CoercionProfVis = false;
                    CoercionAbilityDice = NPC.Willpower;
                    CoercionProfDice = 1;
                }
            }
            if (skill == "Comp" || skill == "All")
            {
                if (NPC.Computers.Rank >= 1)
                {
                    CompProfVis = true;
                    CompAbilityDice = Math.Max(NPC.Intellect, NPC.Computers.Rank);
                    CompProfDice = Math.Min(NPC.Intellect, NPC.Computers.Rank);
                }
                else
                {
                    CompProfVis = false;
                    CompAbilityDice = NPC.Intellect;
                    CompProfDice = 1;
                }
            }
            if (skill == "Cool" || skill == "All")
            {
                if (NPC.Cool.Rank >= 1)
                {
                    CoolProfVis = true;
                    CoolAbilityDice = Math.Max(NPC.Presence, NPC.Cool.Rank);
                    CoolProfDice = Math.Min(NPC.Presence, NPC.Cool.Rank);
                }
                else
                {
                    CoolProfVis = false;
                    CoolAbilityDice = NPC.Presence;
                    CoolProfDice = 1;
                }
            }
            if (skill == "Coord" || skill == "All")
            {
                if (NPC.Coordination.Rank >= 1)
                {
                    CoordProfVis = true;
                    CoordAbilityDice = Math.Max(NPC.Agility, NPC.Coordination.Rank);
                    CoordProfDice = Math.Min(NPC.Agility, NPC.Coordination.Rank);
                }
                else
                {
                    CoordProfVis = false;
                    CoordAbilityDice = NPC.Agility;
                    CoordProfDice = 1;
                }
            }
            if (skill == "Decep" || skill == "All")
            {
                if (NPC.Deception.Rank >= 1)
                {
                    DecepProfVis = true;
                    DecepAbilityDice = Math.Max(NPC.Cunning, NPC.Deception.Rank);
                    DecepProfDice = Math.Min(NPC.Cunning, NPC.Deception.Rank);
                }
                else
                {
                    DecepProfVis = false;
                    DecepAbilityDice = NPC.Cunning;
                    DecepProfDice = 1;
                }
            }
            if (skill == "Disc" || skill == "All")
            {
                if (NPC.Discipline.Rank >= 1)
                {
                    DiscProfVis = true;
                    DiscAbilityDice = Math.Max(NPC.Willpower, NPC.Discipline.Rank);
                    DiscProfDice = Math.Min(NPC.Willpower, NPC.Discipline.Rank);
                }
                else
                {
                    DiscProfVis = false;
                    DiscAbilityDice = NPC.Willpower;
                    DiscProfDice = 1;
                }
            }
            if (skill == "Lead" || skill == "All")
            {
                if (NPC.Leadership.Rank >= 1)
                {
                    LeadProfVis = true;
                    LeadAbilityDice = Math.Max(NPC.Presence, NPC.Leadership.Rank);
                    LeadProfDice = Math.Min(NPC.Presence, NPC.Leadership.Rank);
                }
                else
                {
                    LeadProfVis = false;
                    LeadAbilityDice = NPC.Presence;
                    LeadProfDice = 1;
                }
            }
            if (skill == "Mech" || skill == "All")
            {
                if (NPC.Mechanics.Rank >= 1)
                {
                    MechProfVis = true;
                    MechAbilityDice = Math.Max(NPC.Intellect, NPC.Mechanics.Rank);
                    MechProfDice = Math.Min(NPC.Intellect, NPC.Mechanics.Rank);
                }
                else
                {
                    MechProfVis = false;
                    MechAbilityDice = NPC.Intellect;
                    MechProfDice = 1;
                }
            }
            if (skill == "Med" || skill == "All")
            {
                if (NPC.Medicine.Rank >= 1)
                {
                    MedProfVis = true;
                    MedAbilityDice = Math.Max(NPC.Intellect, NPC.Medicine.Rank);
                    MedProfDice = Math.Min(NPC.Intellect, NPC.Medicine.Rank);
                }
                else
                {
                    MedProfVis = false;
                    MedAbilityDice = NPC.Intellect;
                    MedProfDice = 1;
                }
            }
            if (skill == "Nego" || skill == "All")
            {
                if (NPC.Negotiation.Rank >= 1)
                {
                    NegoProfVis = true;
                    NegoAbilityDice = Math.Max(NPC.Presence, NPC.Negotiation.Rank);
                    NegoProfDice = Math.Min(NPC.Presence, NPC.Negotiation.Rank);
                }
                else
                {
                    NegoProfVis = false;
                    NegoAbilityDice = NPC.Presence;
                    NegoProfDice = 1;
                }
            }
            if (skill == "Percep" || skill == "All")
            {
                if (NPC.Perception.Rank >= 1)
                {
                    PercepProfVis = true;
                    PercepAbilityDice = Math.Max(NPC.Cunning, NPC.Perception.Rank);
                    PercepProfDice = Math.Min(NPC.Cunning, NPC.Perception.Rank);
                }
                else
                {
                    PercepProfVis = false;
                    PercepAbilityDice = NPC.Cunning;
                    PercepProfDice = 1;
                }
            }
            if (skill == "PilotingP" || skill == "All")
            {
                if (NPC.PilotingPlanetary.Rank >= 1)
                {
                    PilotingPProfVis = true;
                    PilotingPAbilityDice = Math.Max(NPC.Agility, NPC.PilotingPlanetary.Rank);
                    PilotingPProfDice = Math.Min(NPC.Agility, NPC.PilotingPlanetary.Rank);
                }
                else
                {
                    PilotingPProfVis = false;
                    PilotingPAbilityDice = NPC.Agility;
                    PilotingPProfDice = 1;
                }
            }
            if (skill == "PilotingS" || skill == "All")
            {
                if (NPC.PilotingSpace.Rank >= 1)
                {
                    PilotingSProfVis = true;
                    PilotingSAbilityDice = Math.Max(NPC.Agility, NPC.PilotingSpace.Rank);
                    PilotingSProfDice = Math.Min(NPC.Agility, NPC.PilotingSpace.Rank);
                }
                else
                {
                    PilotingSProfVis = false;
                    PilotingSAbilityDice = NPC.Agility;
                    PilotingSProfDice = 1;
                }
            }
            if (skill == "Resil" || skill == "All")
            {
                if (NPC.Resilience.Rank >= 1)
                {
                    ResilProfVis = true;
                    ResilAbilityDice = Math.Max(NPC.Brawn, NPC.Resilience.Rank);
                    ResilProfDice = Math.Min(NPC.Brawn, NPC.Resilience.Rank);
                }
                else
                {
                    ResilProfVis = false;
                    ResilAbilityDice = NPC.Brawn;
                    ResilProfDice = 1;
                }
            }
            if (skill == "Skul" || skill == "All")
            {
                if (NPC.Skullduggery.Rank >= 1)
                {
                    SkulProfVis = true;
                    SkulAbilityDice = Math.Max(NPC.Cunning, NPC.Skullduggery.Rank);
                    SkulProfDice = Math.Min(NPC.Cunning, NPC.Skullduggery.Rank);
                }
                else
                {
                    SkulProfVis = false;
                    SkulAbilityDice = NPC.Cunning;
                    SkulProfDice = 1;
                }
            }
            if (skill == "Stealth" || skill == "All")
            {
                if (NPC.Stealth.Rank >= 1)
                {
                    StealthProfVis = true;
                    StealthAbilityDice = Math.Max(NPC.Agility, NPC.Stealth.Rank);
                    StealthProfDice = Math.Min(NPC.Agility, NPC.Stealth.Rank);
                }
                else
                {
                    StealthProfVis = false;
                    StealthAbilityDice = NPC.Agility;
                    StealthProfDice = 1;
                }
            }
            if (skill == "Street" || skill == "All")
            {
                if (NPC.Streetwise.Rank >= 1)
                {
                    StreetProfVis = true;
                    StreetAbilityDice = Math.Max(NPC.Cunning, NPC.Streetwise.Rank);
                    StreetProfDice = Math.Min(NPC.Cunning, NPC.Streetwise.Rank);
                }
                else
                {
                    StreetProfVis = false;
                    StreetAbilityDice = NPC.Cunning;
                    StreetProfDice = 1;
                }
            }
            if (skill == "Surv" || skill == "All")
            {
                if (NPC.Survival.Rank >= 1)
                {
                    SurvProfVis = true;
                    SurvAbilityDice = Math.Max(NPC.Cunning, NPC.Survival.Rank);
                    SurvProfDice = Math.Min(NPC.Cunning, NPC.Survival.Rank);
                }
                else
                {
                    SurvProfVis = false;
                    SurvAbilityDice = NPC.Cunning;
                    SurvProfDice = 1;
                }
            }
            if (skill == "Vigil" || skill == "All")
            {
                if (NPC.Vigilance.Rank >= 1)
                {
                    VigilProfVis = true;
                    VigilAbilityDice = Math.Max(NPC.Willpower, NPC.Vigilance.Rank);
                    VigilProfDice = Math.Min(NPC.Willpower, NPC.Vigilance.Rank);
                }
                else
                {
                    VigilProfVis = false;
                    VigilAbilityDice = NPC.Willpower;
                    VigilProfDice = 1;
                }
            }
            if (skill == "Brawl" || skill == "All")
            {
                if (NPC.Brawl.Rank >= 1)
                {
                    BrawlProfVis = true;
                    BrawlAbilityDice = Math.Max(NPC.Brawn, NPC.Brawl.Rank);
                    BrawlProfDice = Math.Min(NPC.Brawn, NPC.Brawl.Rank);
                }
                else
                {
                    BrawlProfVis = false;
                    BrawlAbilityDice = NPC.Brawn;
                    BrawlProfDice = 1;
                }
            }
            if (skill == "Gunnery" || skill == "All")
            {
                if (NPC.Gunnery.Rank >= 1)
                {
                    GunneryProfVis = true;
                    GunneryAbilityDice = Math.Max(NPC.Agility, NPC.Gunnery.Rank);
                    GunneryProfDice = Math.Min(NPC.Agility, NPC.Gunnery.Rank);
                }
                else
                {
                    GunneryProfVis = false;
                    GunneryAbilityDice = NPC.Agility;
                    GunneryProfDice = 1;
                }
            }
            if (skill == "Melee" || skill == "All")
            {
                if (NPC.Melee.Rank >= 1)
                {
                    MeleeProfVis = true;
                    MeleeAbilityDice = Math.Max(NPC.Brawn, NPC.Melee.Rank);
                    MeleeProfDice = Math.Min(NPC.Brawn, NPC.Melee.Rank);
                }
                else
                {
                    MeleeProfVis = false;
                    MeleeAbilityDice = NPC.Brawn;
                    MeleeProfDice = 1;
                }
            }
            if (skill == "RangedL" || skill == "All")
            {
                if (NPC.RangedLight.Rank >= 1)
                {
                    RangedLProfVis = true;
                    RangedLAbilityDice = Math.Max(NPC.Agility, NPC.RangedLight.Rank);
                    RangedLProfDice = Math.Min(NPC.Agility, NPC.RangedLight.Rank);
                }
                else
                {
                    RangedLProfVis = false;
                    RangedLAbilityDice = NPC.Agility;
                    RangedLProfDice = 1;
                }
            }
            if (skill == "RangedH" || skill == "All")
            {
                if (NPC.RangedHeavy.Rank >= 1)
                {
                    RangedHProfVis = true;
                    RangedHAbilityDice = Math.Max(NPC.Agility, NPC.RangedHeavy.Rank);
                    RangedHProfDice = Math.Min(NPC.Agility, NPC.RangedHeavy.Rank);
                }
                else
                {
                    RangedHProfVis = false;
                    RangedHAbilityDice = NPC.Agility;
                    RangedHProfDice = 1;
                }
            }
            if (skill == "Lightsaber" || skill == "All")
            {
                var LightsaberAttributeRank = 1;
                switch (NPC.LightsaberSkill)
                {
                    case "Brawn":
                        LightsaberAttributeRank = NPC.Brawn;
                        break;
                    case "Agility":
                        LightsaberAttributeRank = NPC.Agility;
                        break;
                    case "Intellect":
                        LightsaberAttributeRank = NPC.Intellect;
                        break;
                    case "Cunning":
                        LightsaberAttributeRank = NPC.Cunning;
                        break;
                    case "Willpower":
                        LightsaberAttributeRank = NPC.Willpower;
                        break;
                    case "Presence":
                        LightsaberAttributeRank = NPC.Presence;
                        break;
                    default:
                        LightsaberAttributeRank = NPC.Brawn;
                        break;
                }
                if (NPC.Lightsaber.Rank >= 1)
                {
                    LightsaberProfVis = true;
                    LightsaberAbilityDice = Math.Max(LightsaberAttributeRank, NPC.Lightsaber.Rank);
                    LightsaberProfDice = Math.Min(LightsaberAttributeRank, NPC.Lightsaber.Rank);
                }
                else
                {
                    LightsaberProfVis = false;
                    LightsaberAbilityDice = LightsaberAttributeRank;
                    LightsaberProfDice = 1;
                }
            }
            if (skill == "CoreKnow" || skill == "All")
            {
                if (NPC.CoreWorldKnow.Rank >= 1)
                {
                    CoreKnowProfVis = true;
                    CoreKnowAbilityDice = Math.Max(NPC.Intellect, NPC.CoreWorldKnow.Rank);
                    CoreKnowProfDice = Math.Min(NPC.Intellect, NPC.CoreWorldKnow.Rank);
                }
                else
                {
                    CoreKnowProfVis = false;
                    CoreKnowAbilityDice = NPC.Intellect;
                    CoreKnowProfDice = 1;
                }
            }
            if (skill == "EduKnow" || skill == "All")
            {
                if (NPC.EducationKnow.Rank >= 1)
                {
                    EduKnowProfVis = true;
                    EduKnowAbilityDice = Math.Max(NPC.Intellect, NPC.EducationKnow.Rank);
                    EduKnowProfDice = Math.Min(NPC.Intellect, NPC.EducationKnow.Rank);
                }
                else
                {
                    EduKnowProfVis = false;
                    EduKnowAbilityDice = NPC.Intellect;
                    EduKnowProfDice = 1;
                }
            }
            if (skill == "LoreKnow" || skill == "All")
            {
                if (NPC.LoreKnow.Rank >= 1)
                {
                    LoreKnowProfVis = true;
                    LoreKnowAbilityDice = Math.Max(NPC.Intellect, NPC.LoreKnow.Rank);
                    LoreKnowProfDice = Math.Min(NPC.Intellect, NPC.LoreKnow.Rank);
                }
                else
                {
                    LoreKnowProfVis = false;
                    LoreKnowAbilityDice = NPC.Intellect;
                    LoreKnowProfDice = 1;
                }
            }
            if (skill == "OuterKnow" || skill == "All")
            {
                if (NPC.OuterRimKnow.Rank >= 1)
                {
                    OuterKnowProfVis = true;
                    OuterKnowAbilityDice = Math.Max(NPC.Intellect, NPC.OuterRimKnow.Rank);
                    OuterKnowProfDice = Math.Min(NPC.Intellect, NPC.OuterRimKnow.Rank);
                }
                else
                {
                    OuterKnowProfVis = false;
                    OuterKnowAbilityDice = NPC.Intellect;
                    OuterKnowProfDice = 1;
                }
            }
            if (skill == "UnderKnow" || skill == "All")
            {
                if (NPC.UnderworldKnow.Rank >= 1)
                {
                    UnderKnowProfVis = true;
                    UnderKnowAbilityDice = Math.Max(NPC.Intellect, NPC.UnderworldKnow.Rank);
                    UnderKnowProfDice = Math.Min(NPC.Intellect, NPC.UnderworldKnow.Rank);
                }
                else
                {
                    UnderKnowProfVis = false;
                    UnderKnowAbilityDice = NPC.Intellect;
                    UnderKnowProfDice = 1;
                }
            }
            if (skill == "WarKnow" || skill == "All")
            {
                if (NPC.WarfareKnow.Rank >= 1)
                {
                    WarKnowProfVis = true;
                    WarKnowAbilityDice = Math.Max(NPC.Intellect, NPC.WarfareKnow.Rank);
                    WarKnowProfDice = Math.Min(NPC.Intellect, NPC.WarfareKnow.Rank);
                }
                else
                {
                    WarKnowProfVis = false;
                    WarKnowAbilityDice = NPC.Intellect;
                    WarKnowProfDice = 1;
                }
            }
            if (skill == "XenoKnow" || skill == "All")
            {
                if (NPC.XenologyKnow.Rank >= 1)
                {
                    XenoKnowProfVis = true;
                    XenoKnowAbilityDice = Math.Max(NPC.Intellect, NPC.XenologyKnow.Rank);
                    XenoKnowProfDice = Math.Min(NPC.Intellect, NPC.XenologyKnow.Rank);
                }
                else
                {
                    XenoKnowProfVis = false;
                    XenoKnowAbilityDice = NPC.Intellect;
                    XenoKnowProfDice = 1;
                }
            }
        }

        private int _astroAbilityDice;
        public int AstroAbilityDice
        {
            get { return _astroAbilityDice; }
            set { SetProperty(ref _astroAbilityDice, value); }
        }
        private int _astroProfDice;
        public int AstroProfDice
        {
            get { return _astroProfDice; }
            set { SetProperty(ref _astroProfDice, value); }
        }
        private bool _astroProfVis;
        public bool AstroProfVis
        {
            get { return _astroProfVis; }
            set { SetProperty(ref _astroProfVis, value); }
        }


        private int _athlAbilityDice;
        public int AthlAbilityDice
        {
            get { return _athlAbilityDice; }
            set { SetProperty(ref _athlAbilityDice, value); }
        }
        private int _athlProfDice;
        public int AthlProfDice
        {
            get { return _athlProfDice; }
            set { SetProperty(ref _athlProfDice, value); }
        }
        private bool _athlProfVis;
        public bool AthlProfVis
        {
            get { return _athlProfVis; }
            set { SetProperty(ref _athlProfVis, value); }
        }


        private int _charmAbilityDice;
        public int CharmAbilityDice
        {
            get { return _charmAbilityDice; }
            set { SetProperty(ref _charmAbilityDice, value); }
        }
        private int _charmProfDice;
        public int CharmProfDice
        {
            get { return _charmProfDice; }
            set { SetProperty(ref _charmProfDice, value); }
        }
        private bool _charmProfVis;
        public bool CharmProfVis
        {
            get { return _charmProfVis; }
            set { SetProperty(ref _charmProfVis, value); }
        }


        private int _coercionAbilityDice;
        public int CoercionAbilityDice
        {
            get { return _coercionAbilityDice; }
            set { SetProperty(ref _coercionAbilityDice, value); }
        }
        private int _coercionProfDice;
        public int CoercionProfDice
        {
            get { return _coercionProfDice; }
            set { SetProperty(ref _coercionProfDice, value); }
        }
        private bool _coercionProfVis;
        public bool CoercionProfVis
        {
            get { return _coercionProfVis; }
            set { SetProperty(ref _coercionProfVis, value); }
        }


        private int _compAbilityDice;
        public int CompAbilityDice
        {
            get { return _compAbilityDice; }
            set { SetProperty(ref _compAbilityDice, value); }
        }
        private int _compProfDice;
        public int CompProfDice
        {
            get { return _compProfDice; }
            set { SetProperty(ref _compProfDice, value); }
        }
        private bool _compProfVis;
        public bool CompProfVis
        {
            get { return _compProfVis; }
            set { SetProperty(ref _compProfVis, value); }
        }


        private int _coolAbilityDice;
        public int CoolAbilityDice
        {
            get { return _coolAbilityDice; }
            set { SetProperty(ref _coolAbilityDice, value); }
        }
        private int _coolProfDice;
        public int CoolProfDice
        {
            get { return _coolProfDice; }
            set { SetProperty(ref _coolProfDice, value); }
        }
        private bool _coolProfVis;
        public bool CoolProfVis
        {
            get { return _coolProfVis; }
            set { SetProperty(ref _coolProfVis, value); }
        }


        private int _coordAbilityDice;
        public int CoordAbilityDice
        {
            get { return _coordAbilityDice; }
            set { SetProperty(ref _coordAbilityDice, value); }
        }
        private int _coordProfDice;
        public int CoordProfDice
        {
            get { return _coordProfDice; }
            set { SetProperty(ref _coordProfDice, value); }
        }
        private bool _coordProfVis;
        public bool CoordProfVis
        {
            get { return _coordProfVis; }
            set { SetProperty(ref _coordProfVis, value); }
        }


        private int _decepAbilityDice;
        public int DecepAbilityDice
        {
            get { return _decepAbilityDice; }
            set { SetProperty(ref _decepAbilityDice, value); }
        }
        private int _decepProfDice;
        public int DecepProfDice
        {
            get { return _decepProfDice; }
            set { SetProperty(ref _decepProfDice, value); }
        }
        private bool _decepProfVis;
        public bool DecepProfVis
        {
            get { return _decepProfVis; }
            set { SetProperty(ref _decepProfVis, value); }
        }


        private int _discAbilityDice;
        public int DiscAbilityDice
        {
            get { return _discAbilityDice; }
            set { SetProperty(ref _discAbilityDice, value); }
        }
        private int _discProfDice;
        public int DiscProfDice
        {
            get { return _discProfDice; }
            set { SetProperty(ref _discProfDice, value); }
        }
        private bool _discProfVis;
        public bool DiscProfVis
        {
            get { return _discProfVis; }
            set { SetProperty(ref _discProfVis, value); }
        }


        private int _leadAbilityDice;
        public int LeadAbilityDice
        {
            get { return _leadAbilityDice; }
            set { SetProperty(ref _leadAbilityDice, value); }
        }
        private int _leadProfDice;
        public int LeadProfDice
        {
            get { return _leadProfDice; }
            set { SetProperty(ref _leadProfDice, value); }
        }
        private bool _leadProfVis;
        public bool LeadProfVis
        {
            get { return _leadProfVis; }
            set { SetProperty(ref _leadProfVis, value); }
        }


        private int _mechAbilityDice;
        public int MechAbilityDice
        {
            get { return _mechAbilityDice; }
            set { SetProperty(ref _mechAbilityDice, value); }
        }
        private int _mechProfDice;
        public int MechProfDice
        {
            get { return _mechProfDice; }
            set { SetProperty(ref _mechProfDice, value); }
        }
        private bool _mechProfVis;
        public bool MechProfVis
        {
            get { return _mechProfVis; }
            set { SetProperty(ref _mechProfVis, value); }
        }


        private int _medAbilityDice;
        public int MedAbilityDice
        {
            get { return _medAbilityDice; }
            set { SetProperty(ref _medAbilityDice, value); }
        }
        private int _medProfDice;
        public int MedProfDice
        {
            get { return _medProfDice; }
            set { SetProperty(ref _medProfDice, value); }
        }
        private bool _medProfVis;
        public bool MedProfVis
        {
            get { return _medProfVis; }
            set { SetProperty(ref _medProfVis, value); }
        }


        private int _negoAbilityDice;
        public int NegoAbilityDice
        {
            get { return _negoAbilityDice; }
            set { SetProperty(ref _negoAbilityDice, value); }
        }
        private int _negoProfDice;
        public int NegoProfDice
        {
            get { return _negoProfDice; }
            set { SetProperty(ref _negoProfDice, value); }
        }
        private bool _negoProfVis;
        public bool NegoProfVis
        {
            get { return _negoProfVis; }
            set { SetProperty(ref _negoProfVis, value); }
        }


        private int _percepAbilityDice;
        public int PercepAbilityDice
        {
            get { return _percepAbilityDice; }
            set { SetProperty(ref _percepAbilityDice, value); }
        }
        private int _percepProfDice;
        public int PercepProfDice
        {
            get { return _percepProfDice; }
            set { SetProperty(ref _percepProfDice, value); }
        }
        private bool _percepProfVis;
        public bool PercepProfVis
        {
            get { return _percepProfVis; }
            set { SetProperty(ref _percepProfVis, value); }
        }


        private int _pilotingPAbilityDice;
        public int PilotingPAbilityDice
        {
            get { return _pilotingPAbilityDice; }
            set { SetProperty(ref _pilotingPAbilityDice, value); }
        }
        private int _pilotingPProfDice;
        public int PilotingPProfDice
        {
            get { return _pilotingPProfDice; }
            set { SetProperty(ref _pilotingPProfDice, value); }
        }
        private bool _pilotingPProfVis;
        public bool PilotingPProfVis
        {
            get { return _pilotingPProfVis; }
            set { SetProperty(ref _pilotingPProfVis, value); }
        }


        private int _pilotingSAbilityDice;
        public int PilotingSAbilityDice
        {
            get { return _pilotingSAbilityDice; }
            set { SetProperty(ref _pilotingSAbilityDice, value); }
        }
        private int _pilotingSProfDice;
        public int PilotingSProfDice
        {
            get { return _pilotingSProfDice; }
            set { SetProperty(ref _pilotingSProfDice, value); }
        }
        private bool _pilotingSProfVis;
        public bool PilotingSProfVis
        {
            get { return _pilotingSProfVis; }
            set { SetProperty(ref _pilotingSProfVis, value); }
        }


        private int _resilAbilityDice;
        public int ResilAbilityDice
        {
            get { return _resilAbilityDice; }
            set { SetProperty(ref _resilAbilityDice, value); }
        }
        private int _resilProfDice;
        public int ResilProfDice
        {
            get { return _resilProfDice; }
            set { SetProperty(ref _resilProfDice, value); }
        }
        private bool _resilProfVis;
        public bool ResilProfVis
        {
            get { return _resilProfVis; }
            set { SetProperty(ref _resilProfVis, value); }
        }


        private int _skulAbilityDice;
        public int SkulAbilityDice
        {
            get { return _skulAbilityDice; }
            set { SetProperty(ref _skulAbilityDice, value); }
        }
        private int _skulProfDice;
        public int SkulProfDice
        {
            get { return _skulProfDice; }
            set { SetProperty(ref _skulProfDice, value); }
        }
        private bool _skulProfVis;
        public bool SkulProfVis
        {
            get { return _skulProfVis; }
            set { SetProperty(ref _skulProfVis, value); }
        }


        private int _stealthAbilityDice;
        public int StealthAbilityDice
        {
            get { return _stealthAbilityDice; }
            set { SetProperty(ref _stealthAbilityDice, value); }
        }
        private int _stealthProfDice;
        public int StealthProfDice
        {
            get { return _stealthProfDice; }
            set { SetProperty(ref _stealthProfDice, value); }
        }
        private bool _stealthProfVis;
        public bool StealthProfVis
        {
            get { return _stealthProfVis; }
            set { SetProperty(ref _stealthProfVis, value); }
        }


        private int _streetAbilityDice;
        public int StreetAbilityDice
        {
            get { return _streetAbilityDice; }
            set { SetProperty(ref _streetAbilityDice, value); }
        }
        private int _streetProfDice;
        public int StreetProfDice
        {
            get { return _streetProfDice; }
            set { SetProperty(ref _streetProfDice, value); }
        }
        private bool _streetProfVis;
        public bool StreetProfVis
        {
            get { return _streetProfVis; }
            set { SetProperty(ref _streetProfVis, value); }
        }


        private int _survAbilityDice;
        public int SurvAbilityDice
        {
            get { return _survAbilityDice; }
            set { SetProperty(ref _survAbilityDice, value); }
        }
        private int _survProfDice;
        public int SurvProfDice
        {
            get { return _survProfDice; }
            set { SetProperty(ref _survProfDice, value); }
        }
        private bool _survProfVis;
        public bool SurvProfVis
        {
            get { return _survProfVis; }
            set { SetProperty(ref _survProfVis, value); }
        }


        private int _vigilAbilityDice;
        public int VigilAbilityDice
        {
            get { return _vigilAbilityDice; }
            set { SetProperty(ref _vigilAbilityDice, value); }
        }
        private int _vigilProfDice;
        public int VigilProfDice
        {
            get { return _vigilProfDice; }
            set { SetProperty(ref _vigilProfDice, value); }
        }
        private bool _vigilProfVis;
        public bool VigilProfVis
        {
            get { return _vigilProfVis; }
            set { SetProperty(ref _vigilProfVis, value); }
        }


        private int _brawlAbilityDice;
        public int BrawlAbilityDice
        {
            get { return _brawlAbilityDice; }
            set { SetProperty(ref _brawlAbilityDice, value); }
        }
        private int _brawlProfDice;
        public int BrawlProfDice
        {
            get { return _brawlProfDice; }
            set { SetProperty(ref _brawlProfDice, value); }
        }
        private bool _brawlProfVis;
        public bool BrawlProfVis
        {
            get { return _brawlProfVis; }
            set { SetProperty(ref _brawlProfVis, value); }
        }


        private int _gunneryAbilityDice;
        public int GunneryAbilityDice
        {
            get { return _gunneryAbilityDice; }
            set { SetProperty(ref _gunneryAbilityDice, value); }
        }
        private int _gunneryProfDice;
        public int GunneryProfDice
        {
            get { return _gunneryProfDice; }
            set { SetProperty(ref _gunneryProfDice, value); }
        }
        private bool _gunneryProfVis;
        public bool GunneryProfVis
        {
            get { return _gunneryProfVis; }
            set { SetProperty(ref _gunneryProfVis, value); }
        }


        private int _meleeAbilityDice;
        public int MeleeAbilityDice
        {
            get { return _meleeAbilityDice; }
            set { SetProperty(ref _meleeAbilityDice, value); }
        }
        private int _meleeProfDice;
        public int MeleeProfDice
        {
            get { return _meleeProfDice; }
            set { SetProperty(ref _meleeProfDice, value); }
        }
        private bool _meleeProfVis;
        public bool MeleeProfVis
        {
            get { return _meleeProfVis; }
            set { SetProperty(ref _meleeProfVis, value); }
        }


        private int _rangedLAbilityDice;
        public int RangedLAbilityDice
        {
            get { return _rangedLAbilityDice; }
            set { SetProperty(ref _rangedLAbilityDice, value); }
        }
        private int _rangedLProfDice;
        public int RangedLProfDice
        {
            get { return _rangedLProfDice; }
            set { SetProperty(ref _rangedLProfDice, value); }
        }
        private bool _rangedLProfVis;
        public bool RangedLProfVis
        {
            get { return _rangedLProfVis; }
            set { SetProperty(ref _rangedLProfVis, value); }
        }


        private int _rangedHAbilityDice;
        public int RangedHAbilityDice
        {
            get { return _rangedHAbilityDice; }
            set { SetProperty(ref _rangedHAbilityDice, value); }
        }
        private int _rangedHProfDice;
        public int RangedHProfDice
        {
            get { return _rangedHProfDice; }
            set { SetProperty(ref _rangedHProfDice, value); }
        }
        private bool _rangedHProfVis;
        public bool RangedHProfVis
        {
            get { return _rangedHProfVis; }
            set { SetProperty(ref _rangedHProfVis, value); }
        }


        private int _lightsaberAbilityDice;
        public int LightsaberAbilityDice
        {
            get { return _lightsaberAbilityDice; }
            set { SetProperty(ref _lightsaberAbilityDice, value); }
        }
        private int _lightsaberProfDice;
        public int LightsaberProfDice
        {
            get { return _lightsaberProfDice; }
            set { SetProperty(ref _lightsaberProfDice, value); }
        }
        private bool _lightsaberProfVis;
        public bool LightsaberProfVis
        {
            get { return _lightsaberProfVis; }
            set { SetProperty(ref _lightsaberProfVis, value); }
        }


        private int _coreKnowAbilityDice;
        public int CoreKnowAbilityDice
        {
            get { return _coreKnowAbilityDice; }
            set { SetProperty(ref _coreKnowAbilityDice, value); }
        }
        private int _coreKnowProfDice;
        public int CoreKnowProfDice
        {
            get { return _coreKnowProfDice; }
            set { SetProperty(ref _coreKnowProfDice, value); }
        }
        private bool _coreKnowProfVis;
        public bool CoreKnowProfVis
        {
            get { return _coreKnowProfVis; }
            set { SetProperty(ref _coreKnowProfVis, value); }
        }


        private int _eduKnowAbilityDice;
        public int EduKnowAbilityDice
        {
            get { return _eduKnowAbilityDice; }
            set { SetProperty(ref _eduKnowAbilityDice, value); }
        }
        private int _eduKnowProfDice;
        public int EduKnowProfDice
        {
            get { return _eduKnowProfDice; }
            set { SetProperty(ref _eduKnowProfDice, value); }
        }
        private bool _eduKnowProfVis;
        public bool EduKnowProfVis
        {
            get { return _eduKnowProfVis; }
            set { SetProperty(ref _eduKnowProfVis, value); }
        }


        private int _loreKnowAbilityDice;
        public int LoreKnowAbilityDice
        {
            get { return _loreKnowAbilityDice; }
            set { SetProperty(ref _loreKnowAbilityDice, value); }
        }
        private int _loreKnowProfDice;
        public int LoreKnowProfDice
        {
            get { return _loreKnowProfDice; }
            set { SetProperty(ref _loreKnowProfDice, value); }
        }
        private bool _loreKnowProfVis;
        public bool LoreKnowProfVis
        {
            get { return _loreKnowProfVis; }
            set { SetProperty(ref _loreKnowProfVis, value); }
        }


        private int _outerKnowAbilityDice;
        public int OuterKnowAbilityDice
        {
            get { return _outerKnowAbilityDice; }
            set { SetProperty(ref _outerKnowAbilityDice, value); }
        }
        private int _outerKnowProfDice;
        public int OuterKnowProfDice
        {
            get { return _outerKnowProfDice; }
            set { SetProperty(ref _outerKnowProfDice, value); }
        }
        private bool _outerKnowProfVis;
        public bool OuterKnowProfVis
        {
            get { return _outerKnowProfVis; }
            set { SetProperty(ref _outerKnowProfVis, value); }
        }


        private int _underKnowAbilityDice;
        public int UnderKnowAbilityDice
        {
            get { return _underKnowAbilityDice; }
            set { SetProperty(ref _underKnowAbilityDice, value); }
        }
        private int _underKnowProfDice;
        public int UnderKnowProfDice
        {
            get { return _underKnowProfDice; }
            set { SetProperty(ref _underKnowProfDice, value); }
        }
        private bool _underKnowProfVis;
        public bool UnderKnowProfVis
        {
            get { return _underKnowProfVis; }
            set { SetProperty(ref _underKnowProfVis, value); }
        }


        private int _warKnowAbilityDice;
        public int WarKnowAbilityDice
        {
            get { return _warKnowAbilityDice; }
            set { SetProperty(ref _warKnowAbilityDice, value); }
        }
        private int _warKnowProfDice;
        public int WarKnowProfDice
        {
            get { return _warKnowProfDice; }
            set { SetProperty(ref _warKnowProfDice, value); }
        }
        private bool _warKnowProfVis;
        public bool WarKnowProfVis
        {
            get { return _warKnowProfVis; }
            set { SetProperty(ref _warKnowProfVis, value); }
        }


        private int _xenoKnowAbilityDice;
        public int XenoKnowAbilityDice
        {
            get { return _xenoKnowAbilityDice; }
            set { SetProperty(ref _xenoKnowAbilityDice, value); }
        }
        private int _xenoKnowProfDice;
        public int XenoKnowProfDice
        {
            get { return _xenoKnowProfDice; }
            set { SetProperty(ref _xenoKnowProfDice, value); }
        }
        private bool _xenoKnowProfVis;
        public bool XenoKnowProfVis
        {
            get { return _xenoKnowProfVis; }
            set { SetProperty(ref _xenoKnowProfVis, value); }
        }


        #endregion

    }
}
