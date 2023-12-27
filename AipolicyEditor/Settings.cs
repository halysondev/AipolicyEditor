using System;
using MadMilkman.Ini;
using System.IO;

namespace AipolicyEditor
{
    public class Settings
    {
        private static IniFile Ini = new IniFile();
        public static string Language
        {
            get => Ini.Sections["GENERAL"].Keys["Language"].Value;
            set
            {
                Ini.Sections["GENERAL"].Keys["Language"].Value = value.ToString();
                Save();
            }
        }
        public static int ConditionType
        {
            get => Ini.Sections["GENERAL"].Keys["ConditionType"].Value.ToInt32();
            set
            {
                Ini.Sections["GENERAL"].Keys["ConditionType"].Value = value.ToString();
                Save();
            }
        }
        public static string ConfigsPath
        {
            get => Ini.Sections["GENERAL"].Keys["ConfigsPath"].Value;
            set
            {
                Ini.Sections["GENERAL"].Keys["ConfigsPath"].Value = value;
                Save();
            }
        }
        public static string ElementsPath
        {
            get => Ini.Sections["GENERAL"].Keys["ElementsPath"].Value;
            set
            {
                Ini.Sections["GENERAL"].Keys["ElementsPath"].Value = value;
                Save();
            }
        }

        public static void Load()
        {
            Ini.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.ini"));
        }

        public static void Save()
        {
            Ini.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.ini"));
        }
    }
}
