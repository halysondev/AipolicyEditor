using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using AngelicaArchiveManager.Core.ArchiveEngine;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace AipolicyEditor.AIPolicy
{
    public class CustomData
    {
        private static LiteDB.LiteDatabase Cache = new LiteDB.LiteDatabase(AppDomain.CurrentDomain.BaseDirectory + "Cache.db");

        public static List<CustomDataCollection> Skills
        {
            get
            {
                if (Cache.CollectionExists("Skills"))
                    return Cache.GetCollection<CustomDataCollection>("Skills").FindAll().ToList();
                return new List<CustomDataCollection>();
            }
        }
        public static List<CustomDataCollection> Npcs
        {
            get
            {
                if (Cache.CollectionExists("Npcs"))
                    return Cache.GetCollection<CustomDataCollection>("Npcs").FindAll().ToList();
                return new List<CustomDataCollection>();
            }
        }
        public static List<CustomDataCollection> Mobs
        {
            get
            {
                if (Cache.CollectionExists("Mobs"))
                    return Cache.GetCollection<CustomDataCollection>("Mobs").FindAll().ToList();
                return new List<CustomDataCollection>();
            }
        }
        public static List<CustomDataCollection> Mines
        {
            get
            {
                if (Cache.CollectionExists("Mines"))
                    return Cache.GetCollection<CustomDataCollection>("Mines").FindAll().ToList();
                return new List<CustomDataCollection>();
            }
        }

        public static void Init()
        {
            if (Cache.CollectionExists("Skills"))
                Cache.DropCollection("Skills");
            if (File.Exists(Settings.ConfigsPath))
            {
                ArchiveManager am = new ArchiveManager(Settings.ConfigsPath, new ArchiveKey());
                am.ReadFileTable();
                var entry = am.Files.Where(x => x.Path.EndsWith("skillstr.txt")).ToList();
                if (entry.Count > 0)
                {
                    byte[] skillstr = am.GetFile(entry.First());
                    StreamReader sr = new StreamReader(new MemoryStream(skillstr));
                    string text = sr.ReadToEnd();
                    Regex r = new Regex(@"^[0-9]+\s{0,10}" + "(\"[^\"]*\")", RegexOptions.Multiline);
                    var collection = r.Matches(text);
                    var enumerator = collection.GetEnumerator();
                    var col = Cache.GetCollection<CustomDataCollection>("Skills");
                    while (enumerator.MoveNext())
                    {
                        var split = enumerator.Current.ToString().Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
                        string id = split[0].Remove(split[0].IndexOf(" ") - 1);
                        string name = split[1].Replace("\"", "");
                        enumerator.MoveNext();
                        col.Insert(new CustomDataCollection()
                        {
                            ID = id.ToInt32(),
                            Name = name,
                            Desc = enumerator.Current.ToString().Substring(enumerator.Current.ToString().IndexOf("\""))
                        });
                    }
                    sr.Close();
                    Utils.MemoryCleaner();
                }
            }
            if (File.Exists(Settings.ElementsPath))
            {
                if (Cache.CollectionExists("Npcs"))
                    Cache.DropCollection("Npcs");
                if (Cache.CollectionExists("Mobs"))
                    Cache.DropCollection("Mobs");
                if (Cache.CollectionExists("Mines"))
                    Cache.DropCollection("Mines");
                var col1 = Cache.GetCollection<CustomDataCollection>("Npcs");
                var col2 = Cache.GetCollection<CustomDataCollection>("Mobs");
                var col3 = Cache.GetCollection<CustomDataCollection>("Mines");
                KuklusDataEditor.Core.ElementsData elements = new KuklusDataEditor.Core.ElementsData();
                try
                {
                    elements.Load(Settings.ElementsPath);
                }
                catch { }
                byte list_count = 0;
                foreach (var list in elements.Lists)
                {
                    if (list_count == 3)
                        break;
                    if (list.Name.Contains("NPC_ESSENCE") ||
                        list.Name.Contains("MONSTER_ESSENCE") ||
                        list.Name.Contains("MINE_ESSENCE"))
                    {
                        foreach (var item in list.Items)
                        {
                            int id = item.Values[list.IDIndex].ToString().ToInt32();
                            string name = item.Values[list.NameIndex].ToString();
                            var data = new CustomDataCollection()
                            {
                                ID = id,
                                Name = name,
                                Desc = ""
                            };
                            if (list.Name.Contains("NPC_ESSENCE"))
                            {
                                col1.Insert(data);
                            }
                            else if (list.Name.Contains("MONSTER_ESSENCE"))
                            {
                                col2.Insert(data);
                            }
                            else if (list.Name.Contains("MINE_ESSENCE"))
                            {
                                col3.Insert(data);
                            }
                        }
                        ++list_count;
                    }
                }
                elements.Lists.Clear();
                Utils.MemoryCleaner();
            }
        }

        public static string GetSkillName(int id)
        {
            var data = Skills.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Name : "Unknown";
        }

        public static string GetSkillDesc(int id)
        {
            var data = Skills.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Desc : "No description";
        }

        public static string GetNpcName(int id)
        {
            var data = Npcs.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Name : "Unknown";
        }

        public static string GetNpcDesc(int id)
        {
            var data = Npcs.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Desc : "No description";
        }

        public static string GetMobName(int id)
        {
            var data = Mobs.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Name : "Unknown";
        }

        public static string GetMobDesc(int id)
        {
            var data = Mobs.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Desc : "No description";
        }

        public static string GetMineName(int id)
        {
            var data = Mines.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Name : "Unknown";
        }

        public static string GetMineDesc(int id)
        {
            var data = Mines.Where(x => x.ID == id).ToList();
            return data.Count > 0 ? data.First().Desc : "No description";
        }
    }
}
