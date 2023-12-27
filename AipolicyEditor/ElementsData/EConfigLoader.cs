using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuklusDataEditor.Core
{
    public class EConfigLoader
    {
        public static (List<EList>, int) LoadConfig(short version)
        {
            List<EList> lists = new List<EList>();
            string[] files = Directory.GetFiles(Path.Combine(Application.StartupPath, "Configs"), "PW_*_v" + version + ".cfg");
            if (files.Length == 0)
                return (null, 0);
            StreamReader sr = new StreamReader(files.First());
            int ListCount = sr.ReadLine().ToInt32();
            int DialogList = sr.ReadLine().ToInt32();
            for (int i = 0; i < ListCount; ++i)
            {
                sr.ReadLine();
                EList list = new EList
                {
                    Name = sr.ReadLine(),
                };
                string offset = sr.ReadLine();
                list.Offset = offset.Contains("AUTO") ? -1 : offset.ToInt32();
                string[] f = sr.ReadLine().Split(';');
                string[] t = sr.ReadLine().Split(';');
                for (int j = 0; j < f.Length; ++j)
                {
                    if (f[j].Contains(":") && f[j].LastIndexOf(':') > f[j].Length - 5)
                    {
                        int count = f[j].Split(':').Last().ToInt32();
                        string field = f[j].Replace($":{count}", "");
                        int StartIndex = f[j].Contains("%1") ? 1 : 0;
                        for (int k = StartIndex; k < count + StartIndex; ++k)
                        {
                            EDataTypes t1, t2;
                            string f1, f2;
                            (t1, t2, f1, f2) = TypeFieldParser(t[j], field);
                            if (t[j].Contains(":") && !t[j].Contains("AUTO"))
                                list.TypeValue.Add(j, t[j].Split(':').Last());
                            if (f1 != null)
                            {
                                if (f1.Contains("%"))
                                {
                                    f1 = f1.Replace("%0", k.ToString()).Replace("%1", k.ToString());
                                }
                                list.Fields.Add(f1);
                                list.Types.Add(t1);
                            }
                            if (f2 != null)
                            {
                                if (f2.Contains("%"))
                                {
                                    f2 = f2.Replace("%0", k.ToString()).Replace("%1", k.ToString());
                                }
                                list.Fields.Add(f2);
                                list.Types.Add(t2);
                            }
                        }
                    }
                    else
                    {
                        EDataTypes t1, t2;
                        string f1, f2;
                        (t1, t2, f1, f2) = TypeFieldParser(t[j], f[j]);
                        if (t[j].Contains(":") && !t[j].Contains("AUTO"))
                            list.TypeValue.Add(j, t[j].Split(':').Last());
                        if (f1 != null)
                        {
                            list.Fields.Add(f1);
                            list.Types.Add(t1);
                        }
                        if (f2 != null)
                        {
                            list.Fields.Add(f2);
                            list.Types.Add(t2);
                        }
                    }
                }
                if (list.Types.IndexOf(EDataTypes.EID) > -1)
                    list.IDIndex = list.Types.IndexOf(EDataTypes.EID);
                if (list.Types.IndexOf(EDataTypes.EName) > -1)
                    list.NameIndex = list.Types.IndexOf(EDataTypes.EName);
                if (list.Types.IndexOf(EDataTypes.EIcon) > -1)
                    list.IconIndex = list.Types.IndexOf(EDataTypes.EIcon);
                if (list.IconIndex > -1)
                    list.HasIcon = true;
                lists.Add(list);
            }
            return (lists, DialogList);
        }

        public static (EDataTypes, EDataTypes, string, string) TypeFieldParser(string type, string field)
        {
            string[] fields = field.Split(':');
            switch (type)
            {
                case string s when s.Contains("int") && field.Contains("ID"):
                    return (EDataTypes.EID, EDataTypes.ENull, field, null);
                case string s when s.Contains("string") && field.Contains("Name"):
                    return (EDataTypes.EName, EDataTypes.ENull, field, null);
                case string s when s.Contains("string") && field.Contains("file_icon"):
                    return (EDataTypes.EIcon, EDataTypes.ENull, field, null);
                case string s when s.StartsWith("item_id"):
                    return (EDataTypes.EItem, EDataTypes.ENull, field, null);
                case string s when s.StartsWith("item_prob"):
                    return (EDataTypes.EItemProb, EDataTypes.EFloat, fields.First(), fields.Last());
                case string s when s.StartsWith("item_count"):
                    return (EDataTypes.EItemCount, EDataTypes.EInt32, fields.First(), fields.Last());
                case string s when s.StartsWith("addon_id"):
                    return (EDataTypes.EAddon, EDataTypes.ENull, null, null);
                case string s when s.StartsWith("addon_prob"):
                    return (EDataTypes.EAddonProb, EDataTypes.EFloat, fields.First(), fields.Last());
                case string s when s.StartsWith("mask"):
                    return (EDataTypes.EMask, EDataTypes.ENull, field, null);
                case string s when s.StartsWith("link"):
                    return (EDataTypes.ELink, EDataTypes.ENull, field, null);
                case string s when s.StartsWith("model"):
                    return (EDataTypes.EModel, EDataTypes.ENull, field, null);
                case "int32":
                    return (EDataTypes.EInt32, EDataTypes.ENull, field, null);
                case "float":
                    return (EDataTypes.EFloat, EDataTypes.ENull, field, null);
                case "color":
                    return (EDataTypes.EColor, EDataTypes.ENull, field, null);
                case string s when s.StartsWith("wstring"):
                    return (EDataTypes.EUString, EDataTypes.ENull, field, null);
                case string s when s.StartsWith("string"):
                    return (EDataTypes.ECString, EDataTypes.ENull, field, null);
                default:
                    return (EDataTypes.ENull, EDataTypes.ENull, null, null);
            }
        }
    }
}