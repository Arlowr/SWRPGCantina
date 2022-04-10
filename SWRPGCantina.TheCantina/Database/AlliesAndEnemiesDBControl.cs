using SWRPGCantina.Core.Generics;
using SWRPGCantina.TheCantina.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWRPGCantina.TheCantina.Database
{
    public class AlliesAndEnemiesDBControl
    {
        private string DBCon { get; set; }

        public AlliesAndEnemiesDBControl()
        {
            DBCon = generics.databaseLoc;
        }
        public List<NPC> GetNPCs()
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

                    SqlDataAdapter getTeam = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getTeam.Fill(dsT);
                    var t = dsT.Tables[0].AsEnumerable().Select(o => new NPC()
                    {
                        DBID = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["AdversaryName"] != DBNull.Value ? o.Field<string>("AdversaryName") : "",
                        NPCType = o["NPCType"] != DBNull.Value ? o.Field<string>("NPCType") : "None",
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
                        ForcePoolAvailable = o["ForcePoolAvailable"] != DBNull.Value ? o.Field<int>("ForcePoolAvailable") : 0
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
                    cmd.Parameters.Add("@NPCDescription", SqlDbType.VarChar).Value = npc.CharacterDescription;
                    cmd.Parameters.Add("@Species", SqlDbType.VarChar).Value = npc.Species;
                    cmd.Parameters.Add("@Height", SqlDbType.Int).Value = npc.Height;
                    cmd.Parameters.Add("@Eyes", SqlDbType.VarChar).Value = npc.EyeColour;
                    cmd.Parameters.Add("@Build", SqlDbType.VarChar).Value = npc.Build;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = npc.Gender;
                    cmd.Parameters.Add("@Hair", SqlDbType.VarChar).Value = npc.HairColour;
                    cmd.Parameters.Add("@Age", SqlDbType.Int).Value = npc.Age;

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
                    //cmd.Parameters.Add("@ArmourId", SqlDbType.Int).Value = npc.ArmourId;
                    if (npc.Skills != null)
                    {
                        cmd.Parameters.Add("@Astrogation", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Astrogation").Rank;
                        cmd.Parameters.Add("@Athletics", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Athletics").Rank;
                        cmd.Parameters.Add("@Charm", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Charm").Rank;
                        cmd.Parameters.Add("@Coercion", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Coercion").Rank;
                        cmd.Parameters.Add("@Computers", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Computers").Rank;
                        cmd.Parameters.Add("@Cool", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Cool").Rank;
                        cmd.Parameters.Add("@Coordination", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Coordination").Rank;
                        cmd.Parameters.Add("@Deception", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Deception").Rank;
                        cmd.Parameters.Add("@Discipline", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Discipline").Rank;
                        cmd.Parameters.Add("@Leadership", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Leadership").Rank;
                        cmd.Parameters.Add("@Mechanics", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Mechanics").Rank;
                        cmd.Parameters.Add("@Negotiation", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Negotiation").Rank;
                        cmd.Parameters.Add("@Perception", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Perception").Rank;
                        cmd.Parameters.Add("@PilotingPlanetary", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "PilotingPlanetary").Rank;
                        cmd.Parameters.Add("@PilotingSpace", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "PilotingSpace").Rank;
                        cmd.Parameters.Add("@Resilience", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Resilience").Rank;
                        cmd.Parameters.Add("@Skullduggery", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Skullduggery").Rank;
                        cmd.Parameters.Add("@Stealth", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Stealth").Rank;
                        cmd.Parameters.Add("@Streetwise", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Streetwise").Rank;
                        cmd.Parameters.Add("@Survival", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Survival").Rank;
                        cmd.Parameters.Add("@Vigilance", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Vigilance").Rank;
                        cmd.Parameters.Add("@Brawl", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Brawl").Rank;
                        cmd.Parameters.Add("@Gunnery", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Gunnery").Rank;
                        cmd.Parameters.Add("@Lightsaber", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Lightsaber").Rank;
                        cmd.Parameters.Add("@Melee", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "Melee").Rank;
                        cmd.Parameters.Add("@RangedLight", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "RangedLight").Rank;
                        cmd.Parameters.Add("@RangedHeavy", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "RangedHeavy").Rank;
                        cmd.Parameters.Add("@CoreWorldKnow", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "CoreWorldKnowledge").Rank;
                        cmd.Parameters.Add("@EducationKnow", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "EducationKnowledge").Rank;
                        cmd.Parameters.Add("@LoreKnow", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "LoreKnowledge").Rank;
                        cmd.Parameters.Add("@OuterRimKnow", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "OuterRimKnowledge").Rank;
                        cmd.Parameters.Add("@UnderworldKnow", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "UnderworldKnowledge").Rank;
                        cmd.Parameters.Add("@WarfareKnow", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "WarfareKnowledge").Rank;
                        cmd.Parameters.Add("@XenologyKnow", SqlDbType.Int).Value = npc.Skills.FirstOrDefault(x => x.Name == "XenologyKnowledge").Rank;
                    }
                    cmd.Parameters.Add("@Credit", SqlDbType.VarChar).Value = npc.Source;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();

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
