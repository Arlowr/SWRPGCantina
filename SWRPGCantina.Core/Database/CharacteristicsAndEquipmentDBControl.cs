using SWRPGCantina.Core.Generics;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWRPGCantina.Core.Database
{
    public class CharacteristicsAndEquipmentDBControl
    {
        private string DBCon { get; set; }

        public CharacteristicsAndEquipmentDBControl()
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

                    SqlDataAdapter getTalents = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getTalents.Fill(dsT);
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

        public List<Gear> GetListOfGear()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetGear]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getGear = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getGear.Fill(dsT);
                    var EquipmentTable = dsT.Tables[0].AsEnumerable().Select(o => new Gear()
                    {
                        DbId = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["Item"] != DBNull.Value ? o.Field<string>("Item") : "",
                        GearType = "Equipment",
                        Description = o["ItemDescription"] != DBNull.Value ? o.Field<string>("ItemDescription") : "",
                        Encumbrance = o["Encumbrance"] != DBNull.Value ? o.Field<int>("Encumbrance") : 0,
                        Price = o["Price"] != DBNull.Value ? o.Field<int>("Price") : 0,
                        Rarity = o["Rarity"] != DBNull.Value ? o.Field<int>("Rarity") : 0
                    });
                    var WeaponsTable = dsT.Tables[1].AsEnumerable().Select(o => new Gear()
                    {
                        DbId = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["WeaponName"] != DBNull.Value ? o.Field<string>("WeaponName") : "",
                        GearType = "Weapon",
                        Description = o["Description"] != DBNull.Value ? o.Field<string>("Description") : "",
                        Encumbrance = o["Encumbrance"] != DBNull.Value ? o.Field<int>("Encumbrance") : 0,
                        Price = o["Price"] != DBNull.Value ? o.Field<int>("Price") : 0,
                        Rarity = o["Rarity"] != DBNull.Value ? o.Field<int>("Rarity") : 0,
                        WeaponSkill = o["WeaponSkill"] != DBNull.Value ? o.Field<string>("WeaponSkill") : "",
                        Damage = o["Damage"] != DBNull.Value ? o.Field<int>("Damage") : 0,
                        CritValue = o["Crit"] != DBNull.Value ? o.Field<int>("Crit") : 0,
                        Range = o["WeaponRange"] != DBNull.Value ? o.Field<string>("WeaponRange") : "",
                        HardPoints = o["HardPoints"] != DBNull.Value ? o.Field<int>("HardPoints") : 0,
                        Qualities = o["Qualities"] != DBNull.Value ? o.Field<string>("Qualities") : ""
                    });
                    var ArmourTable = dsT.Tables[2].AsEnumerable().Select(o => new Gear()
                    {
                        DbId = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["ArmourName"] != DBNull.Value ? o.Field<string>("ArmourName") : "",
                        GearType = "Armour",
                        Description = o["Description"] != DBNull.Value ? o.Field<string>("Description") : "",
                        Encumbrance = o["Encumbrance"] != DBNull.Value ? o.Field<int>("Encumbrance") : 0,
                        Price = o["Price"] != DBNull.Value ? o.Field<int>("Price") : 0,
                        Rarity = o["Rarity"] != DBNull.Value ? o.Field<int>("Rarity") : 0,
                        Defence = o["Defence"] != DBNull.Value ? o.Field<int>("Defence") : 0,
                        Soak = o["Soak"] != DBNull.Value ? o.Field<int>("Soak") : 0,
                        HardPoints = o["HardPoints"] != DBNull.Value ? o.Field<int>("HardPoints") : 0,
                        Qualities = o["Qualities"] != DBNull.Value ? o.Field<string>("Qualities") : ""
                    });

                    conn.Close();

                    List<Gear> AllGear = new List<Gear>();
                    foreach (var Equipment in EquipmentTable)
                    {
                        AllGear.Add(Equipment);
                    }
                    foreach (var Weapon in WeaponsTable)
                    {
                        AllGear.Add(Weapon);
                    }
                    foreach (var Armour in ArmourTable)
                    {
                        AllGear.Add(Armour);
                    }

                    return AllGear;
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }
        public List<Weapon> GetListOfWeapons()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetWeapons]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getWeapons = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getWeapons.Fill(dsT);
                    var Weapons = dsT.Tables[0].AsEnumerable().Select(o => new Weapon()
                    {
                        DbId = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["WeaponName"] != DBNull.Value ? o.Field<string>("WeaponName") : "",
                        Description = o["Description"] != DBNull.Value ? o.Field<string>("Description") : "",
                        Encumbrance = o["Encumbrance"] != DBNull.Value ? o.Field<int>("Encumbrance") : 0,
                        Price = o["Price"] != DBNull.Value ? o.Field<int>("Price") : 0,
                        Rarity = o["Rarity"] != DBNull.Value ? o.Field<int>("Rarity") : 0,
                        WeaponSkill = o["WeaponSkill"] != DBNull.Value ? o.Field<string>("WeaponSkill") : "",
                        Damage = o["Damage"] != DBNull.Value ? o.Field<int>("Damage") : 0,
                        CritValue = o["Crit"] != DBNull.Value ? o.Field<int>("Crit") : 0,
                        Range = o["WeaponRange"] != DBNull.Value ? o.Field<string>("WeaponRange") : "",
                        HardPoints = o["HardPoints"] != DBNull.Value ? o.Field<int>("HardPoints") : 0,
                        Qualities = o["Qualities"] != DBNull.Value ? o.Field<string>("Qualities") : ""
                    }).ToList();

                    conn.Close();

                    return Weapons;
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }
        public List<Armour> GetListOfArmour()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetArmour]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getArmour = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getArmour.Fill(dsT);
                    var Armour = dsT.Tables[0].AsEnumerable().Select(o => new Armour()
                    {
                        DbId = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["ArmourName"] != DBNull.Value ? o.Field<string>("ArmourName") : "",
                        Description = o["Description"] != DBNull.Value ? o.Field<string>("Description") : "",
                        Encumbrance = o["Encumbrance"] != DBNull.Value ? o.Field<int>("Encumbrance") : 0,
                        Price = o["Price"] != DBNull.Value ? o.Field<int>("Price") : 0,
                        Rarity = o["Rarity"] != DBNull.Value ? o.Field<int>("Rarity") : 0,
                        RangedDefence = o["RangedDefence"] != DBNull.Value ? o.Field<int>("RangedDefence") : 0,
                        MeleeDefence = o["MeleeDefence"] != DBNull.Value ? o.Field<int>("MeleeDefence") : 0,
                        Soak = o["Soak"] != DBNull.Value ? o.Field<int>("Soak") : 0,
                        HardPoints = o["HardPoints"] != DBNull.Value ? o.Field<int>("HardPoints") : 0,
                        Qualities = o["Qualities"] != DBNull.Value ? o.Field<string>("Qualities") : ""
                    }).ToList();

                    conn.Close();

                    return Armour;
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }
        public List<Equipment> GetListOfEquipment()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[GetEquipment]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    conn.Open();

                    SqlDataAdapter getEquipment = new SqlDataAdapter(cmd);

                    DataSet dsT = new DataSet();
                    getEquipment.Fill(dsT);
                    var Equipment = dsT.Tables[0].AsEnumerable().Select(o => new Equipment()
                    {
                        DbId = o["Id"] != DBNull.Value ? o.Field<int>("Id") : 0,
                        Name = o["Item"] != DBNull.Value ? o.Field<string>("Item") : "",
                        Description = o["ItemDescription"] != DBNull.Value ? o.Field<string>("ItemDescription") : "",
                        ItemType = o["ItemType"] != DBNull.Value ? o.Field<string>("ItemType") : "",
                        Encumbrance = o["Encumbrance"] != DBNull.Value ? o.Field<int>("Encumbrance") : 0,
                        Price = o["Price"] != DBNull.Value ? o.Field<int>("Price") : 0,
                        Rarity = o["Rarity"] != DBNull.Value ? o.Field<int>("Rarity") : 0,
                        Qualities = o["Qualities"] != DBNull.Value ? o.Field<string>("Qualities") : ""
                    }).ToList();

                    conn.Close();

                    return Equipment;
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }


        public bool AddOrUpdateWeapon(Weapon Weapon)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[AddUpdateWeapon]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@WeaponId", SqlDbType.VarChar).Value = Weapon.DbId;
                    cmd.Parameters.Add("@Weapon_Name", SqlDbType.VarChar).Value = Weapon.Name;
                    cmd.Parameters.Add("@Weapon_Text", SqlDbType.VarChar).Value = Weapon.Description;
                    cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = Weapon.Price;
                    cmd.Parameters.Add("@Encumbrance", SqlDbType.VarChar).Value = Weapon.Encumbrance;
                    cmd.Parameters.Add("@Rarity", SqlDbType.VarChar).Value = Weapon.Rarity;
                    cmd.Parameters.Add("@WeaponSkill", SqlDbType.VarChar).Value = Weapon.WeaponSkill;
                    cmd.Parameters.Add("@Damage", SqlDbType.VarChar).Value = Weapon.Damage;
                    cmd.Parameters.Add("@CritValue", SqlDbType.VarChar).Value = Weapon.CritValue;
                    cmd.Parameters.Add("@Range", SqlDbType.VarChar).Value = Weapon.Range;
                    cmd.Parameters.Add("@HardPoints", SqlDbType.VarChar).Value = Weapon.HardPoints;
                    cmd.Parameters.Add("@SingleHanded", SqlDbType.VarChar).Value = Weapon.SingleHanded;
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
        public bool AddOrUpdateArmour(Armour Armour)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[AddUpdateArmour]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ArmourId", SqlDbType.VarChar).Value = Armour.DbId;
                    cmd.Parameters.Add("@Armour_Name", SqlDbType.VarChar).Value = Armour.Name;
                    cmd.Parameters.Add("@Armour_Text", SqlDbType.VarChar).Value = Armour.Description;
                    cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = Armour.Price;
                    cmd.Parameters.Add("@Encumbrance", SqlDbType.VarChar).Value = Armour.Encumbrance;
                    cmd.Parameters.Add("@Rarity", SqlDbType.VarChar).Value = Armour.Rarity;
                    cmd.Parameters.Add("@Qualities", SqlDbType.VarChar).Value = Armour.Qualities;
                    cmd.Parameters.Add("@MeleeDefence", SqlDbType.VarChar).Value = Armour.MeleeDefence;
                    cmd.Parameters.Add("@RangedDefence", SqlDbType.VarChar).Value = Armour.RangedDefence;
                    cmd.Parameters.Add("@Soak", SqlDbType.VarChar).Value = Armour.Soak;
                    cmd.Parameters.Add("@HardPoints", SqlDbType.VarChar).Value = Armour.HardPoints;
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
        public bool AddOrUpdateEquipment(Equipment Equipment)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(DBCon);
                    cmd.CommandText = "[dbo].[AddUpdateEquipment]";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EquipmentId", SqlDbType.VarChar).Value = Equipment.DbId;
                    cmd.Parameters.Add("@Equipment_Name", SqlDbType.VarChar).Value = Equipment.Name;
                    cmd.Parameters.Add("@Equipment_Text", SqlDbType.VarChar).Value = Equipment.Description;
                    cmd.Parameters.Add("@ItemType", SqlDbType.VarChar).Value = Equipment.ItemType;
                    cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = Equipment.Price;
                    cmd.Parameters.Add("@Encumbrance", SqlDbType.VarChar).Value = Equipment.Encumbrance;
                    cmd.Parameters.Add("@Rarity", SqlDbType.VarChar).Value = Equipment.Rarity;
                    cmd.Parameters.Add("@Qualities", SqlDbType.VarChar).Value = Equipment.Qualities;
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
