using SWRPGCantina.Core.Generics;
using SWRPGCantina.Core.Database.DBModels;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.Core.Database
{
    public class AlliesAndEnemiesDBControl
    {
        private string DBCon { get; set; }

        public AlliesAndEnemiesDBControl()
        {
            DBCon = generics.databaseLoc;
        }

        public NPC GetDetailsForNPC(NPC npcNeedingDetails)
        {
            var skills = GetNPCSkillRanks(npcNeedingDetails.DBID);

            npcNeedingDetails = AddSkillsToNPC(skills, npcNeedingDetails);

            return npcNeedingDetails;
        }

        public List<NPC> GetAllNPCsAllDetails()
        {
            List<NPC> AllNpcs = new List<NPC>();

            AllNpcs = GetListOfNPCs();

            foreach (var NPC in AllNpcs)
            {
                GetDetailsForNPC(NPC);
            }

            return AllNpcs;
        }


        public List<NPC> GetListOfNPCs()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetNPCs]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getNPCs = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getNPCs.Fill(dsT);
                    var t = dsT.Tables[0].AsEnumerable().Select(o => new NPC()
                    {
                        DBID = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["AdversaryName"] != DBNull.Value ? o.Field<string>("AdversaryName") : "",
                        NPCType = o["NPCType"] != DBNull.Value ? o.Field<string>("NPCType") : "None",
                        NPCAlignment = o["NPCAlignment"] != DBNull.Value ? o.Field<string>("NPCAlignment") : "None",
                        NPCAffiliation = o["NPCAffiliation"] != DBNull.Value ? o.Field<string>("NPCAffiliation") : "None",
                        RarityRank = o["RarityRank"] != DBNull.Value ? o.Field<int>("RarityRank") : 1,
                        CharacterDescription = o["NPCDescription"] != DBNull.Value ? o.Field<string>("NPCDescription") : "",
                        Species = o["Species"] != DBNull.Value ? o.Field<string>("Species") : "",
                        Gender = o["Gender"] != DBNull.Value ? o.Field<string>("Gender") : "",
                        Height = o["Height"] != DBNull.Value ? o.Field<double>("Height") : 0,
                        EyeColour = o["Eyes"] != DBNull.Value ? o.Field<string>("Eyes") : "",
                        Build = o["Build"] != DBNull.Value ? o.Field<string>("Build") : "",
                        HairColour = o["Hair"] != DBNull.Value ? o.Field<string>("Hair") : "",
                        Age = o["Age"] != DBNull.Value ? o.Field<int>("Age") : 50,
                        Brawn = o["Brawn"] != DBNull.Value ? o.Field<int>("Brawn") : 1,
                        Agility = o["Agility"] != DBNull.Value ? o.Field<int>("Agility") : 1,
                        Intellect = o["Intellect"] != DBNull.Value ? o.Field<int>("Intellect") : 1,
                        Cunning = o["Cunning"] != DBNull.Value ? o.Field<int>("Cunning") : 1,
                        Willpower = o["Willpower"] != DBNull.Value ? o.Field<int>("Willpower") : 1,
                        Presence = o["Presence"] != DBNull.Value ? o.Field<int>("Presence") : 1,
                        ForceRating = o["ForceRating"] != DBNull.Value ? o.Field<int>("ForceRating") : 0,
                        WoundThreshold = o["WoundThreshold"] != DBNull.Value ? o.Field<int>("WoundThreshold") : 10,
                        CurrentWounds = o["CurrentWounds"] != DBNull.Value ? o.Field<int>("CurrentWounds") : 0,
                        StrainThreshold = o["StrainThreshold"] != DBNull.Value ? o.Field<int>("StrainThreshold") : 10,
                        CurrentStrain = o["CurrentStrain"] != DBNull.Value ? o.Field<int>("CurrentStrain") : 0,
                        Soak = o["Soak"] != DBNull.Value ? o.Field<int>("Soak") : 0,
                        DefenceMelee = o["DefenceMelee"] != DBNull.Value ? o.Field<int>("DefenceMelee") : 0,
                        DefenceRanged = o["DefenceRanged"] != DBNull.Value ? o.Field<int>("DefenceRanged") : 0,
                        ForcePoolCommited = o["ForcePoolCommited"] != DBNull.Value ? o.Field<int>("ForcePoolCommited") : 0,
                        ForcePoolAvailable = o["ForcePoolAvailable"] != DBNull.Value ? o.Field<int>("ForcePoolAvailable") : 0,
                        ForcePoolMax = o["ForcePoolMax"] != DBNull.Value ? o.Field<int>("ForcePoolMax") : 0,
                        LightsaberSkill = o["LightsaberSkill"] != DBNull.Value ? o.Field<string>("LightsaberSkill") : ""
                    });

                    conn.Close();

                    return t.ToList();
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }

        private DBSkillsList GetNPCSkillRanks(int npcID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetNPCSkills]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NPCDBID", SqlDbType.VarChar).Value = npcID;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getSkills = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getSkills.Fill(dsT);
                    var t = dsT.Tables[0].AsEnumerable().Select(o => new DBSkillsList()
                    {
                        DBID = npcID,
                        ASTROGATION = o["Astrogation"] != DBNull.Value ? o.Field<int>("Astrogation") : 0,
                        ATHLETICS = o["Athletics"] != DBNull.Value ? o.Field<int>("Athletics") : 0,
                        CHARM = o["Charm"] != DBNull.Value ? o.Field<int>("Charm") : 0,
                        COERCION = o["Coercion"] != DBNull.Value ? o.Field<int>("Coercion") : 0,
                        COMPUTER = o["Computers"] != DBNull.Value ? o.Field<int>("Computers") : 0,
                        COOL = o["Cool"] != DBNull.Value ? o.Field<int>("Cool") : 0,
                        COORDINATION = o["Coordination"] != DBNull.Value ? o.Field<int>("Coordination") : 0,
                        DECEPTION = o["Deception"] != DBNull.Value ? o.Field<int>("Deception") : 0,
                        DISCIPLINE = o["Discipline"] != DBNull.Value ? o.Field<int>("Discipline") : 0,
                        LEADERSHIP = o["Leadership"] != DBNull.Value ? o.Field<int>("Leadership") : 0,
                        MECHANICS = o["Mechanics"] != DBNull.Value ? o.Field<int>("Mechanics") : 0,
                        MEDICINE = o["Medicine"] != DBNull.Value ? o.Field<int>("Medicine") : 0,
                        NEGOTIATION = o["Negotiation"] != DBNull.Value ? o.Field<int>("Negotiation") : 0,
                        PERCEPTION = o["Perception"] != DBNull.Value ? o.Field<int>("Perception") : 0,
                        PILOTINGPLANETARY = o["PilotingPlanetary"] != DBNull.Value ? o.Field<int>("PilotingPlanetary") : 0,
                        PILOTINGSPACE = o["PilotingSpace"] != DBNull.Value ? o.Field<int>("PilotingSpace") : 0,
                        RESILIENCE = o["Resilience"] != DBNull.Value ? o.Field<int>("Resilience") : 0,
                        SKULLDUGGERY = o["Skullduggery"] != DBNull.Value ? o.Field<int>("Skullduggery") : 0,
                        STEALTH = o["Stealth"] != DBNull.Value ? o.Field<int>("Stealth") : 0,
                        STREETWISE = o["Streetwise"] != DBNull.Value ? o.Field<int>("Streetwise") : 0,
                        SURVIVAL = o["Survival"] != DBNull.Value ? o.Field<int>("Survival") : 0,
                        VIGILANCE = o["Vigilance"] != DBNull.Value ? o.Field<int>("Vigilance") : 0,
                        BRAWL = o["Brawl"] != DBNull.Value ? o.Field<int>("Brawl") : 0,
                        GUNNERY = o["Gunnery"] != DBNull.Value ? o.Field<int>("Gunnery") : 0,
                        LIGHTSABER = o["Lightsaber"] != DBNull.Value ? o.Field<int>("Lightsaber") : 0,
                        MELEE = o["Melee"] != DBNull.Value ? o.Field<int>("Melee") : 0,
                        RANGEDLIGHT = o["RangedLight"] != DBNull.Value ? o.Field<int>("RangedLight") : 0,
                        RANGEDHEAVY = o["RangedHeavy"] != DBNull.Value ? o.Field<int>("RangedHeavy") : 0,
                        COREWORLDLKNOW = o["CoreWorldKnow"] != DBNull.Value ? o.Field<int>("CoreWorldKnow") : 0,
                        EDUCATIONKNOW = o["EducationKnow"] != DBNull.Value ? o.Field<int>("EducationKnow") : 0,
                        LOREKNOW = o["LoreKnow"] != DBNull.Value ? o.Field<int>("LoreKnow") : 0,
                        OUTERRIMKNOW = o["OuterRimKnow"] != DBNull.Value ? o.Field<int>("OuterRimKnow") : 0,
                        UNDERWORLDKNOW = o["UnderworldKnow"] != DBNull.Value ? o.Field<int>("UnderworldKnow") : 0,
                        WARFAREKNOW = o["WarfareKnow"] != DBNull.Value ? o.Field<int>("WarfareKnow") : 0,
                        XENOLOGYKNOW = o["XenologyKnow"] != DBNull.Value ? o.Field<int>("XenologyKnow") : 0
                    });

                    conn.Close();

                    return t.FirstOrDefault();
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }

        public NPC AddSkillsToNPC(DBSkillsList DBSkillsToChange, NPC npcNeedingDetails)
        {
            List<Skill> Skills = new List<Skill>();

            npcNeedingDetails.Astrogation = new Skill { Name = "Astrogation", Rank = DBSkillsToChange.ASTROGATION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Athletics = new Skill { Name = "Athletics", Rank = DBSkillsToChange.ATHLETICS, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Charm = new Skill { Name = "Charm", Rank = DBSkillsToChange.CHARM, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Coercion = new Skill { Name = "Coercion", Rank = DBSkillsToChange.COERCION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Computers = new Skill { Name = "Computers", Rank = DBSkillsToChange.COMPUTER, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Cool = new Skill { Name = "Cool", Rank = DBSkillsToChange.COOL, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Coordination = new Skill { Name = "Coordination", Rank = DBSkillsToChange.COORDINATION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Deception = new Skill { Name = "Deception", Rank = DBSkillsToChange.DECEPTION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Discipline = new Skill { Name = "Discipline", Rank = DBSkillsToChange.DISCIPLINE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Leadership = new Skill { Name = "Leadership", Rank = DBSkillsToChange.LEADERSHIP, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Mechanics = new Skill { Name = "Mechanics", Rank = DBSkillsToChange.MECHANICS, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Medicine = new Skill { Name = "Medicine", Rank = DBSkillsToChange.MEDICINE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Negotiation = new Skill { Name = "Negotiation", Rank = DBSkillsToChange.NEGOTIATION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Perception = new Skill { Name = "Perception", Rank = DBSkillsToChange.PERCEPTION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.PilotingPlanetary = new Skill { Name = "PilotingPlanetary", Rank = DBSkillsToChange.PILOTINGPLANETARY, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.PilotingSpace = new Skill { Name = "PilotingSpace", Rank = DBSkillsToChange.PILOTINGSPACE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Resilience = new Skill { Name = "Resilience", Rank = DBSkillsToChange.RESILIENCE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Skullduggery = new Skill { Name = "Skullduggery", Rank = DBSkillsToChange.SKULLDUGGERY, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Stealth = new Skill { Name = "Stealth", Rank = DBSkillsToChange.STEALTH, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Streetwise = new Skill { Name = "Streetwise", Rank = DBSkillsToChange.STREETWISE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Survival = new Skill { Name = "Survival", Rank = DBSkillsToChange.SURVIVAL, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Vigilance = new Skill { Name = "Vigilance", Rank = DBSkillsToChange.VIGILANCE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.Brawl = new Skill { Name = "Brawl", Rank = DBSkillsToChange.BRAWL, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            npcNeedingDetails.Gunnery = new Skill { Name = "Gunnery", Rank = DBSkillsToChange.GUNNERY, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            npcNeedingDetails.Lightsaber = new Skill { Name = "Lightsaber", Rank = DBSkillsToChange.LIGHTSABER, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            npcNeedingDetails.Melee = new Skill { Name = "Melee", Rank = DBSkillsToChange.MELEE, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            npcNeedingDetails.RangedLight = new Skill { Name = "RangedLight", Rank = DBSkillsToChange.RANGEDLIGHT, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            npcNeedingDetails.RangedHeavy = new Skill { Name = "RangedHeavy", Rank = DBSkillsToChange.RANGEDHEAVY, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false };
            npcNeedingDetails.CoreWorldKnow = new Skill { Name = "CoreWorldKnow", Rank = DBSkillsToChange.COREWORLDLKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.EducationKnow = new Skill { Name = "EducationKnow", Rank = DBSkillsToChange.EDUCATIONKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.LoreKnow = new Skill { Name = "LoreKnow", Rank = DBSkillsToChange.LOREKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.OuterRimKnow = new Skill { Name = "OuterRimKnow", Rank = DBSkillsToChange.OUTERRIMKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.UnderworldKnow = new Skill { Name = "UnderworldKnow", Rank = DBSkillsToChange.UNDERWORLDKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.WarfareKnow = new Skill { Name = "WarfareKnow", Rank = DBSkillsToChange.WARFAREKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };
            npcNeedingDetails.XenologyKnow = new Skill { Name = "XenologyKnow", Rank = DBSkillsToChange.XENOLOGYKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false };

            return npcNeedingDetails;
        }

        public List<Talent> GetNPCTalents(int npcID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetNPCTalents]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NPCDBID", SqlDbType.VarChar).Value = npcID;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getNPCs = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getNPCs.Fill(dsT);
                    var t = dsT.Tables[0].AsEnumerable().Select(o => new Talent()
                    {
                        DbId = o["TalentID"] != DBNull.Value ? o.Field<int>("TalentID") : 0,
                        Name = o["Title"] != DBNull.Value ? o.Field<string>("Title") : "",
                        Description = o["TalentText"] != DBNull.Value ? o.Field<string>("TalentText") : "",
                        IsForceTalent = o["IsForceTalent"] != DBNull.Value ? o.Field<bool>("IsForceTalent") : false,
                        IsActiveTalent = o["IsActive"] != DBNull.Value ? o.Field<bool>("IsActive") : false,
                        StatIncreaseName = o["StatIncreasename"] != DBNull.Value ? o.Field<string>("StatIncreasename") : "",
                        StatIncrease = o["StatIncNum"] != DBNull.Value ? o.Field<int>("StatIncNum") : 0,
                        NeedsRanks = o["NeedsRanks"] != DBNull.Value ? o.Field<bool>("NeedsRanks") : false,
                        Rank = o["Rank"] != DBNull.Value ? o.Field<int>("Rank") : 0,
                        CharacterDBInt = npcID
                    });

                    conn.Close();

                    return t.ToList();
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }

        public bool AddOrUpdateAdversary(NPC npc)
        {
            string ListOfTalents = "";
            bool first = true;
            foreach (var talent in npc.Talents)
            {
                if (first)
                {
                    ListOfTalents = talent.DbId.ToString();
                }
                else
                {
                    ListOfTalents = ListOfTalents + "," + talent.DbId.ToString();
                }
                first = false;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[AddUpdateAdversary]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NPCDBID", SqlDbType.VarChar).Value = npc.DBID;
                    cmd.Parameters.Add("@AdversaryName", SqlDbType.VarChar).Value = npc.Name;
                    cmd.Parameters.Add("@NPCType", SqlDbType.VarChar).Value = npc.NPCType;
                    cmd.Parameters.Add("@NPCAlignment", SqlDbType.VarChar).Value = npc.NPCAlignment;
                    cmd.Parameters.Add("@NPCAffiliation", SqlDbType.VarChar).Value = npc.NPCAffiliation;
                    cmd.Parameters.Add("@NPCDescription", SqlDbType.VarChar).Value = npc.CharacterDescription;
                    cmd.Parameters.Add("@RarityRank", SqlDbType.VarChar).Value = npc.RarityRank;
                    cmd.Parameters.Add("@Species", SqlDbType.VarChar).Value = npc.Species;
                    cmd.Parameters.Add("@Height", SqlDbType.Int).Value = npc.Height;
                    cmd.Parameters.Add("@Eyes", SqlDbType.VarChar).Value = npc.EyeColour;
                    cmd.Parameters.Add("@Build", SqlDbType.VarChar).Value = npc.Build;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = npc.Gender;
                    cmd.Parameters.Add("@Hair", SqlDbType.VarChar).Value = npc.HairColour;
                    cmd.Parameters.Add("@Age", SqlDbType.Int).Value = npc.Age;
                    cmd.Parameters.Add("@LightsaberSkill", SqlDbType.VarChar).Value = npc.LightsaberSkill;

                    cmd.Parameters.Add("@Brawn", SqlDbType.Int).Value = npc.Brawn;
                    cmd.Parameters.Add("@Agility", SqlDbType.Int).Value = npc.Agility;
                    cmd.Parameters.Add("@Intellect", SqlDbType.Int).Value = npc.Intellect;
                    cmd.Parameters.Add("@Cunning", SqlDbType.Int).Value = npc.Cunning;
                    cmd.Parameters.Add("@Willpower", SqlDbType.Int).Value = npc.Willpower;
                    cmd.Parameters.Add("@Presence", SqlDbType.Int).Value = npc.Presence;
                    cmd.Parameters.Add("@ForceRating", SqlDbType.Int).Value = npc.ForceRating;
                    cmd.Parameters.Add("@WoundThreshold", SqlDbType.Int).Value = npc.WoundThreshold;
                    cmd.Parameters.Add("@CurrentWounds", SqlDbType.Int).Value = npc.CurrentWounds;
                    cmd.Parameters.Add("@StrainThreshold", SqlDbType.Int).Value = npc.StrainThreshold;
                    cmd.Parameters.Add("@CurrentStrain", SqlDbType.Int).Value = npc.CurrentStrain;
                    cmd.Parameters.Add("@Soak", SqlDbType.Int).Value = npc.Soak;
                    cmd.Parameters.Add("@DefenceRanged", SqlDbType.Int).Value = npc.DefenceRanged;
                    cmd.Parameters.Add("@DefenceMelee", SqlDbType.Int).Value = npc.DefenceMelee;
                    cmd.Parameters.Add("@ForcePoolCommited", SqlDbType.Int).Value = npc.ForcePoolCommited;
                    cmd.Parameters.Add("@ForcePoolAvailable", SqlDbType.Int).Value = npc.ForcePoolAvailable;
                    cmd.Parameters.Add("@ForcePoolMax", SqlDbType.Int).Value = npc.ForcePoolMax;
                    //cmd.Parameters.Add("@ArmourId", SqlDbType.Int).Value = npc.ArmourId;
                    cmd.Parameters.Add("@Astrogation", SqlDbType.Int).Value = npc.Astrogation.Rank;
                    cmd.Parameters.Add("@Athletics", SqlDbType.Int).Value = npc.Athletics.Rank;
                    cmd.Parameters.Add("@Charm", SqlDbType.Int).Value = npc.Charm.Rank;
                    cmd.Parameters.Add("@Coercion", SqlDbType.Int).Value = npc.Coercion.Rank;
                    cmd.Parameters.Add("@Computers", SqlDbType.Int).Value = npc.Computers.Rank;
                    cmd.Parameters.Add("@Cool", SqlDbType.Int).Value = npc.Cool.Rank;
                    cmd.Parameters.Add("@Coordination", SqlDbType.Int).Value = npc.Coordination.Rank;
                    cmd.Parameters.Add("@Deception", SqlDbType.Int).Value = npc.Deception.Rank;
                    cmd.Parameters.Add("@Discipline", SqlDbType.Int).Value = npc.Discipline.Rank;
                    cmd.Parameters.Add("@Leadership", SqlDbType.Int).Value = npc.Leadership.Rank;
                    cmd.Parameters.Add("@Mechanics", SqlDbType.Int).Value = npc.Mechanics.Rank;
                    cmd.Parameters.Add("@Medicine", SqlDbType.Int).Value = npc.Medicine.Rank;
                    cmd.Parameters.Add("@Negotiation", SqlDbType.Int).Value = npc.Negotiation.Rank;
                    cmd.Parameters.Add("@Perception", SqlDbType.Int).Value = npc.Perception.Rank;
                    cmd.Parameters.Add("@PilotingPlanetary", SqlDbType.Int).Value = npc.PilotingPlanetary.Rank;
                    cmd.Parameters.Add("@PilotingSpace", SqlDbType.Int).Value = npc.PilotingSpace.Rank;
                    cmd.Parameters.Add("@Resilience", SqlDbType.Int).Value = npc.Resilience.Rank;
                    cmd.Parameters.Add("@Skullduggery", SqlDbType.Int).Value = npc.Skullduggery.Rank;
                    cmd.Parameters.Add("@Stealth", SqlDbType.Int).Value = npc.Stealth.Rank;
                    cmd.Parameters.Add("@Streetwise", SqlDbType.Int).Value = npc.Streetwise.Rank;
                    cmd.Parameters.Add("@Survival", SqlDbType.Int).Value = npc.Survival.Rank;
                    cmd.Parameters.Add("@Vigilance", SqlDbType.Int).Value = npc.Vigilance.Rank;
                    cmd.Parameters.Add("@Brawl", SqlDbType.Int).Value = npc.Brawl.Rank;
                    cmd.Parameters.Add("@Gunnery", SqlDbType.Int).Value = npc.Gunnery.Rank;
                    cmd.Parameters.Add("@Lightsaber", SqlDbType.Int).Value = npc.Lightsaber.Rank;
                    cmd.Parameters.Add("@Melee", SqlDbType.Int).Value = npc.Melee.Rank;
                    cmd.Parameters.Add("@RangedLight", SqlDbType.Int).Value = npc.RangedLight.Rank;
                    cmd.Parameters.Add("@RangedHeavy", SqlDbType.Int).Value = npc.RangedHeavy.Rank;
                    cmd.Parameters.Add("@CoreWorldKnow", SqlDbType.Int).Value = npc.CoreWorldKnow.Rank;
                    cmd.Parameters.Add("@EducationKnow", SqlDbType.Int).Value = npc.EducationKnow.Rank;
                    cmd.Parameters.Add("@LoreKnow", SqlDbType.Int).Value = npc.LoreKnow.Rank;
                    cmd.Parameters.Add("@OuterRimKnow", SqlDbType.Int).Value = npc.OuterRimKnow.Rank;
                    cmd.Parameters.Add("@UnderworldKnow", SqlDbType.Int).Value = npc.UnderworldKnow.Rank;
                    cmd.Parameters.Add("@WarfareKnow", SqlDbType.Int).Value = npc.WarfareKnow.Rank;
                    cmd.Parameters.Add("@XenologyKnow", SqlDbType.Int).Value = npc.XenologyKnow.Rank;
                    cmd.Parameters.Add("@Credit", SqlDbType.VarChar).Value = npc.Source;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    if (string.IsNullOrEmpty(ListOfTalents))
                    {
                        cmd.CommandText = "[dbo].[RemoveNPCsTalents]";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@NPCDBID", SqlDbType.Int).Value = npc.DBID;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "[dbo].[AddUpdateAdversaryTalents]";

                        foreach (var talent in npc.Talents)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@NPCDBID", SqlDbType.Int).Value = npc.DBID;
                            cmd.Parameters.Add("@ListOfTalentIDsToKeep", SqlDbType.VarChar).Value = ListOfTalents;
                            cmd.Parameters.Add("@TalentID", SqlDbType.Int).Value = talent.DbId;
                            cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = talent.Rank;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                return false;
            }
        }

    }
}
