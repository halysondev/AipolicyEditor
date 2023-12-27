using AipolicyEditor.AIPolicy;
using AipolicyEditor.AIPolicy.Operations;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using AipolicyEditor.Localization;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WPFLocalizeExtension.Engine;

namespace AipolicyEditor
{
    public partial class MainWindow : MetroWindow
    {
        public AIFile Aipolicy { get; set; }
        public static LocalizationProvider Provider = new LocalizationProvider();

        public MainWindow()
        {
            InitializeComponent();
            LocalizeDictionary.Instance.DefaultProvider = Provider;
            Loaded += MainWindow_Loaded;
        }

        protected override void OnClosed(EventArgs e)
        {
            Environment.Exit(0);
            base.OnClosed(e);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Settings.Load();
                Provider.ChangeLanguage(Settings.Language);
                Aipolicy = new AIFile();
                DataContext = Aipolicy;
                Condition.IsCentral = true;
                SearchFlyout.Aipolicy = Aipolicy;
                #region Custom editors
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(SkillID),
                    Editor = new SkillSelector()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(NpcID),
                    Editor = new NpcSelector()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(MobID),
                    Editor = new MobSelector()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(MineID),
                    Editor = new MineSelector()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(TalkTextAppendDataMask),
                    Editor = new TranslatedEnumEditor()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(FactionPVPPointType),
                    Editor = new TranslatedEnumEditor()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(OperatorType),
                    Editor = new TranslatedEnumEditor()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(VarType),
                    Editor = new TranslatedEnumEditor()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(MonsterPatrolSpeedType),
                    Editor = new TranslatedEnumEditor()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(MonsterPatrolType),
                    Editor = new TranslatedEnumEditor()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(SummoneeDisppearType),
                    Editor = new TranslatedEnumEditor()
                }); 
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(ChatChannels2),
                    Editor = new TranslatedEnumEditor()
                });
                Operation.CustomEditorCollection.Add(new Syncfusion.Windows.PropertyGrid.CustomEditor()
                {
                    HasPropertyType = true,
                    PropertyType = typeof(TargetParam),
                    Editor = new TargetEditor()
                });
                #endregion
            }
            catch (Exception ex)
            {
                Utils.ShowMessage($"Send to developer\n\n{ex.Message}\n\n{ex.Source}\n\n{ex.StackTrace}");
            }
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Aipolicy.data(*.data)|*.data|All files(*.*)|*.*"
            };
            if (ofd.ShowDialog() == true)
            {
                Aipolicy.Read(ofd.FileName);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Aipolicy.Save();
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Aipolicy.data(*.data)|*.data|All files(*.*)|*.*"
            };
            if (sfd.ShowDialog() == true)
            {
                Aipolicy.SaveAs(sfd.FileName);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //SearchFlyout.IsOpen = !SearchFlyout.IsOpen;
            new SearchWin()
            {
                Aipolicy = Aipolicy
            }.Show();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWin().ShowDialog();
        }

        private void Tools_Click(object sender, RoutedEventArgs e)
        {
            new AdditionalWin()
            {
                Aipolicy = Aipolicy
            }.ShowDialog();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Utils.ShowMessage($"Aipolicy.data editor\n" +
                $"Powered by Kn1fe-Zone.Ru\n" +
                $"Authors:\n" +
                $"Kn1fe\n" +
                $"Nes\n" +
                $"© 2018\n" +
                $"Updated by Haly and xDarK - Brazil\n" +
                $"2023");
        }

        #region Controllers
        private void Controllers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Controllers.SelectedIndex > -1)
                Controllers.ScrollIntoView(Controllers.SelectedItem);
            Condition.Cond = null;
            Condition.Reload();
        }

        private void CloneController(object sender, RoutedEventArgs e)
        {
            if (Aipolicy.ControllerIndex > -1)
            {
                Aipolicy.Controllers.Add(Aipolicy.CurrentController.Clone() as CPolicyData);
            }
        }

        private void AddController(object sender, RoutedEventArgs e)
        {
            CPolicyData cpd = new CPolicyData()
            {
                Version = CPolicyData.MaxVersion,
                ID = Aipolicy.Controllers.Count > 0 ? Aipolicy.Controllers.Last().ID + 1 : 1
            };
            Aipolicy.Controllers.Add(cpd);
        }

        private void RemoveController(object sender, RoutedEventArgs e)
        {
            if (Controllers.SelectedIndex > -1)
            {
                Aipolicy.Controllers.RemoveAt(Controllers.SelectedIndex);
            }
        }

        private void ExportController(object sender, RoutedEventArgs e)
        {
            if (Controllers.SelectedItems.Count < 1)
                return;
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = $"ai_controller_{Controllers.SelectedItems.Count}.aie"
            };
            if (sfd.ShowDialog() == true)
            {
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(sfd.FileName));
                bw.Write(Controllers.SelectedItems.Count);
                for (int i = 0; i < Controllers.SelectedItems.Count; ++i)
                {
                    var data = Aipolicy.Controllers.Where(x => x == Controllers.SelectedItems[i]).ToList();
                    if (data.Count > 0)
                    {
                        data.First().Write(bw);
                    }
                }
                bw.Close();
            }
        }

        private void ImportController(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "AIE export files(*.aie)|*.aie|All files(*.*)|*.*"
            };
            if (ofd.ShowDialog() == true)
            {
                BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));
                int count = br.ReadInt32();
                for (int i = 0; i < count; ++i)
                {
                    var data = new CPolicyData();
                    data.Read(br);
                    Aipolicy.Controllers.Add(data);
                }
                br.Close();
            }
        }
        #endregion

        #region Triggers
        private void Triggers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Triggers.SelectedIndex > -1)
                Triggers.ScrollIntoView(Triggers.SelectedItem);
            if (Aipolicy.CurrentTrigger != null)
            {
                Dispatcher.Invoke(new Action(() => Condition.Cond = Aipolicy.CurrentTrigger.RootConditon));
            }
        }

        private void CloneTrigger(object sender, RoutedEventArgs e)
        {
            if (Aipolicy.TriggerIndex > -1)
            {
                Aipolicy.CurrentTriggers.Add(Aipolicy.CurrentTrigger.Clone() as CTriggerData);
            }
        }

        private void AddTrigger(object sender, RoutedEventArgs e)
        {
            CTriggerData ctd = new CTriggerData
            {
                Version = CTriggerData.MaxVersion,
                ID = Aipolicy.CurrentTriggers.Count > 0 ? Aipolicy.CurrentTriggers.Last().ID + 1 : 0
            };
            Aipolicy.CurrentTriggers.Add(ctd);
        }

        private void RemoveTrigger(object sender, RoutedEventArgs e)
        {
            if (Triggers.SelectedIndex > -1)
            {
                Aipolicy.CurrentTriggers.RemoveAt(Triggers.SelectedIndex);
            }
        }

        private void ExportTrigger(object sender, RoutedEventArgs e)
        {
            if (Triggers.SelectedItems.Count < 1)
                return;
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = $"ai_trigger_{Triggers.SelectedItems.Count}.aie"
            };
            if (sfd.ShowDialog() == true)
            {
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(sfd.FileName));
                bw.Write(Triggers.SelectedItems.Count);
                for (int i = 0; i < Triggers.SelectedItems.Count; ++i)
                {
                    var data = Aipolicy.CurrentTriggers.Where(x => x == Triggers.SelectedItems[i]).ToList();
                    if (data.Count > 0)
                    {
                        data.First().Write(bw);
                    }
                }
                bw.Close();
            }
        }

        private void ImportTrigger(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "AIE export files(*.aie)|*.aie|All files(*.*)|*.*"
            };
            if (ofd.ShowDialog() == true)
            {
                BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));
                int count = br.ReadInt32();
                for (int i = 0; i < count; ++i)
                {
                    var data = new CTriggerData();
                    data.Read(br);
                    Aipolicy.CurrentTriggers.Add(data);
                }
                br.Close();
            }
        }
        #endregion

        #region Operations
        private void Operations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Operations.SelectedIndex > -1)
                Operations.ScrollIntoView(Operations.SelectedItem);
        }

        private void CloneOperation(object sender, RoutedEventArgs e)
        {
            if (Aipolicy.OperationIndex > -1)
            {
                Aipolicy.CurrentOperations.Add((Aipolicy.CurrentOperation as ICloneable).Clone() as IOperation);
            }
        }

        private void AddOperation(object sender, RoutedEventArgs e)
        {
            OperationSelector os = new OperationSelector(Aipolicy.CurrentTrigger.Version);
            os.ShowDialog();
            if (os.Op != null)
                Aipolicy.CurrentTrigger.Operations.Add(os.Op);
        }

        private void RemoveOperation(object sender, RoutedEventArgs e)
        {
            if (Operations.SelectedIndex > -1)
            {
                Aipolicy.CurrentTrigger.Operations.RemoveAt(Operations.SelectedIndex);
            }
        }

        private void ExportOperation(object sender, RoutedEventArgs e)
        {
            if (Operations.SelectedItems.Count < 1)
                return;
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = $"ai_operation_{Operations.SelectedItems.Count}.aie"
            };
            if (sfd.ShowDialog() == true)
            {
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(sfd.FileName));
                bw.Write(Operations.SelectedItems.Count);
                bw.Write(Aipolicy.CurrentTrigger.Version);
                for (int i = 0; i < Operations.SelectedItems.Count; ++i)
                {
                    var data = Aipolicy.CurrentTrigger.Operations.Where(x => x == Operations.SelectedItems[i]).ToList();
                    if (data.Count > 0)
                    {
                        bw.Write(data.First().OperID);
                        data.First().Write(bw);
                    }
                }
                bw.Close();
            }
        }

        private void ImportOperation(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "AIE export files(*.aie)|*.aie|All files(*.*)|*.*"
            };
            if (ofd.ShowDialog() == true)
            {
                BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));
                int count = br.ReadInt32();
                int version = br.ReadInt32();
                for (int i = 0; i < count; ++i)
                {
                    int id = br.ReadInt32();
                    var data = AIPolicy.Operation.Read(br, version, id);
                    Aipolicy.CurrentOperations.Add(data);
                }
                br.Close();
            }
        }
        #endregion
    }
}