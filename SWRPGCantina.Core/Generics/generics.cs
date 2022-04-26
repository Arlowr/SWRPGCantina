using SWRPGCantina.Core.Database.DBModels;
using SWRPGCantina.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SWRPGCantina.Core.Generics
{
    public static class generics
    {
        public static string dataManagementType { get; set; }
        public static string databaseLoc { get; set; }
        private static int NumTasksRunning { get; set; }
        private static bool backgroundTasksRunning { get; set; }

        public async static void ErrorManagement(string errorType, string module, string error)
        {
            var fileLoc = System.Reflection.Assembly.GetEntryAssembly().Location;
            switch (errorType)
            {
                case "Database":
                    using (StreamWriter sw = new StreamWriter(Path.Combine(fileLoc, module + "databaseError.txt")))
                    {

                        await sw.WriteAsync(DateTime.Now.ToString("MM/dd/yy H:mm:ss") + "; " + error);
                    }
                    break;
                default:
                    break;
            }
        }

        public static void UpdateTaskRunning(bool taskStarted)
        {
            if (taskStarted)
                NumTasksRunning += 1;
            else
                NumTasksRunning -= 1;

            if (NumTasksRunning > 0)
                backgroundTasksRunning = true;
            else if (NumTasksRunning <= 0)
            {
                backgroundTasksRunning = false;
                NumTasksRunning = 0;
            }
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            var parent = parentObject as T;
            if (parent != null)
                return parent;

            return FindParent<T>(parentObject);

        }

        public static List<Skill> DBToSkillList(DBSkillsList DBSkillsToChange)
        {
            List<Skill> Skills = new List<Skill>();

            Skills.Add(new Skill { Name = "Astrogation", Rank = DBSkillsToChange.ASTROGATION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Athletics", Rank = DBSkillsToChange.ATHLETICS, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Charm", Rank = DBSkillsToChange.CHARM, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Coercion", Rank = DBSkillsToChange.COERCION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Computer", Rank = DBSkillsToChange.COMPUTER, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Cool", Rank = DBSkillsToChange.COOL, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Coordination", Rank = DBSkillsToChange.COORDINATION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Deception", Rank = DBSkillsToChange.DECEPTION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Discipline", Rank = DBSkillsToChange.DISCIPLINE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Leadership", Rank = DBSkillsToChange.LEADERSHIP, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Mechanics", Rank = DBSkillsToChange.MECHANICS, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Negotiation", Rank = DBSkillsToChange.NEGOTIATION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Perception", Rank = DBSkillsToChange.PERCEPTION, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "PilotingPlanetary", Rank = DBSkillsToChange.PILOTINGPLANETARY, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "PilotingSpace", Rank = DBSkillsToChange.PILOTINGSPACE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Resilience", Rank = DBSkillsToChange.RESILIENCE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Skullduggery", Rank = DBSkillsToChange.SKULLDUGGERY, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Stealth", Rank = DBSkillsToChange.STEALTH, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Streetwise", Rank = DBSkillsToChange.STREETWISE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Survival", Rank = DBSkillsToChange.SURVIVAL, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Vigilance", Rank = DBSkillsToChange.VIGILANCE, IsKnowledgeSkill = false, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "Brawl", Rank = DBSkillsToChange.BRAWL, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false });
            Skills.Add(new Skill { Name = "Gunnery", Rank = DBSkillsToChange.GUNNERY, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false });
            Skills.Add(new Skill { Name = "Lightsaber", Rank = DBSkillsToChange.LIGHTSABER, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false });
            Skills.Add(new Skill { Name = "Melee", Rank = DBSkillsToChange.MELEE, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false });
            Skills.Add(new Skill { Name = "RangedLight", Rank = DBSkillsToChange.RANGEDLIGHT, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false });
            Skills.Add(new Skill { Name = "RangedHeavy", Rank = DBSkillsToChange.RANGEDHEAVY, IsKnowledgeSkill = false, IsWeaponSkill = true, Career = false });
            Skills.Add(new Skill { Name = "CoreWorldKnow", Rank = DBSkillsToChange.COREWORLDLKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "EducationKnow", Rank = DBSkillsToChange.EDUCATIONKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "LoreKnow", Rank = DBSkillsToChange.LOREKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "OuterRimKnow", Rank = DBSkillsToChange.OUTERRIMKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "UnderworldKnow", Rank = DBSkillsToChange.UNDERWORLDKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "WarfareKnow", Rank = DBSkillsToChange.WARFAREKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false });
            Skills.Add(new Skill { Name = "XenologyKnow", Rank = DBSkillsToChange.XENOLOGYKNOW, IsKnowledgeSkill = true, IsWeaponSkill = false, Career = false });

            return Skills;
        }
    }
}
