using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Versioning;
using AipolicyEditor.Compatibility;

namespace AipolicyEditor
{
    [SupportedOSPlatform("windows")]
    public class Settings
    {
        private static IniFileWrapper Ini = new IniFileWrapper(Path.Combine(Utils.GetCurrentProcessFolder(), "Settings.ini"));
        public static string Language
        {
            get => Ini.GetValue("GENERAL", "Language", "en-US");
            set
            {
                Ini.SetValue("GENERAL", "Language", value.ToString());
                Save();
            }
        }
        public static int ConditionType
        {
            get => int.Parse(Ini.GetValue("GENERAL", "ConditionType", "0"));
            set
            {
                Ini.SetValue("GENERAL", "ConditionType", value.ToString());
                Save();
            }
        }

        public static int AuttomaticallyConvertToLastVersion
        {
            get => int.Parse(Ini.GetValue("GENERAL", "AuttomaticallyConvertToLastVersion", "0"));
            set
            {
                Ini.SetValue("GENERAL", "AuttomaticallyConvertToLastVersion", "0"); //value.ToString();
                Save();
            }
        }
        public static string ConfigsPath
        {
            get => Ini.GetValue("GENERAL", "ConfigsPath", "");
            set
            {
                Ini.SetValue("GENERAL", "ConfigsPath", value);
                Save();
            }
        }
        public static string ElementsPath
        {
            get => Ini.GetValue("GENERAL", "ElementsPath", "");
            set
            {
                Ini.SetValue("GENERAL", "ElementsPath", value);
                Save();
            }
        }

        public static void Load()
        {
            Ini.Load();
        }

        public static void Save()
        {
            Ini.Save();
        }
    }
}
