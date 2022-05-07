using SWRPGCantina.Core.Generics;
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
    public class SkillsAndTalentsDBControl
    {
        private string DBCon { get; set; }

        public SkillsAndTalentsDBControl()
        {
            DBCon = generics.databaseLoc;
        }

        public List<Talent> GetListOfTalents()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetTalents]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getNPCs = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getNPCs.Fill(dsT);
                    var t = dsT.Tables[0].AsEnumerable().Select(o => new Talent()
                    {
                        DbId = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["Title"] != DBNull.Value ? o.Field<string>("Title") : "",
                        Description = o["TalentText"] != DBNull.Value ? o.Field<string>("TalentText") : "",
                        NeedsRanks = o["NeedsRanks"] != DBNull.Value ? o.Field<bool>("NeedsRanks") : false,
                        IsForceTalent = o["IsForceTalent"] != DBNull.Value ? o.Field<bool>("IsForceTalent") : false,
                        IsActiveTalent = o["IsActive"] != DBNull.Value ? o.Field<bool>("IsActive") : false,
                        StatIncreaseName = o["StatIncreasename"] != DBNull.Value ? o.Field<string>("StatIncreasename") : "",
                        StatIncrease = o["StatIncNum"] != DBNull.Value ? o.Field<int>("StatIncNum") : 0,
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


        public bool AddOrUpdateTalent(Talent talent)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[AddUpdateTalent]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TalentId", SqlDbType.VarChar).Value = talent.DbId;
                    cmd.Parameters.Add("@Talent_Name", SqlDbType.VarChar).Value = talent.Name;
                    cmd.Parameters.Add("@Talent_Text", SqlDbType.VarChar).Value = talent.Description;
                    cmd.Parameters.Add("@IsForce", SqlDbType.VarChar).Value = talent.IsForceTalent;
                    cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = talent.IsActiveTalent;
                    cmd.Parameters.Add("@StatIncrName", SqlDbType.VarChar).Value = talent.StatIncreaseName;
                    cmd.Parameters.Add("@StatIncrNum", SqlDbType.VarChar).Value = talent.StatIncrease;
                    cmd.Parameters.Add("@NeedsRanks", SqlDbType.VarChar).Value = talent.NeedsRanks;
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
