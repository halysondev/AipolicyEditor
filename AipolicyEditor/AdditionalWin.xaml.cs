using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AipolicyEditor.AIPolicy;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor
{
    public partial class AdditionalWin : MetroWindow
    {
        public AIFile Aipolicy { get; set; }

        public AdditionalWin()
        {
            InitializeComponent();
        }

        private void RemoveEmptyControllers(object sender, RoutedEventArgs e)
        {
            int count = 0;
            var forremove = new List<CPolicyData>();
            foreach (var c in Aipolicy.Controllers)
            {
                if (c.Triggers.Count == 0)
                {
                    forremove.Add(c);
                    ++count;
                }
            }
            foreach (var c in forremove)
            {
                Aipolicy.Controllers.Remove(c);
            }
            Utils.ShowMessage($"{MainWindow.Provider.GetLocalizedString("RemovedControllersCount")}: {count}");
        }

        private void TranslateUsingOtherFile(object sender, RoutedEventArgs e)
        {
            int count = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                var ai = new AIFile()
                {
                    InAnotherThread = false
                };
                ai.Read(ofd.FileName);
                for (int i = 0; i < Aipolicy.Controllers.Count; ++i)
                {
                    for (int j = 0; j < Aipolicy.Controllers[i].Triggers.Count; ++j)
                    {
                        for (int k = 0; k < Aipolicy.Controllers[i].Triggers[j].Operations.Count; ++k)
                        {
                            if (Aipolicy.Controllers[i].Triggers[j].Operations[k].OperID == 2)
                            {
                                var f1 = ai.Controllers.Where(x => x.ID == Aipolicy.Controllers[i].ID).ToList();
                                if (f1.Count > 0)
                                {
                                    var f2 = f1.First().Triggers.Where(x => x.ID == Aipolicy.Controllers[i].Triggers[j].ID).ToList();
                                    if (f2.Count > 0)
                                    {
                                        if (f2.First().Operations.Count > k && f2.First().Operations[k].OperID == 2)
                                        {
                                            Aipolicy.Controllers[i].Triggers[j].Operations[k] = f2.First().Operations[k];
                                        }
                                        var f3 = f2.First().Operations.Where(x => x.OperID == 2).ToList();
                                        if (f3.Count > 0)
                                        {
                                            Aipolicy.Controllers[i].Triggers[j].Operations[k] = f3.First();
                                            ++count;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Utils.ShowMessage($"{MainWindow.Provider.GetLocalizedString("TranslateUsingOtherFileCount")}: {count}");
        }
    }
}
