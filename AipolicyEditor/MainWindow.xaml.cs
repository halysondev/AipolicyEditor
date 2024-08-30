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

        private void AutoConvert(object sender, RoutedEventArgs e)
        {
            // Encontrar a maior versão entre todos os triggers
            int maxVersion = Aipolicy.Controllers
                .SelectMany(controller => controller.Triggers)
                .Max(trigger => trigger.Version);

            // Atualizar todos os triggers para a maior versão encontrada
            foreach (var controller in Aipolicy.Controllers)
            {
                foreach (var trigger in controller.Triggers)
                {
                    trigger.Version = maxVersion;
                }
            }

            Aipolicy.Save();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            //if(Settings.AuttomaticallyConvertToLastVersion == 1)
            //{
            //    AutoConvert(sender, e);
            //}
            //else
            //{
                Aipolicy.Save();
            //}
            
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
        //https://github.com/halysondev/AipolicyEditor
        private void About_Click(object sender, RoutedEventArgs e)
        {
            string message =
                "Aipolicy.data Editor\n" +
                "GitHub: https://github.com/halysondev/AipolicyEditor\n" +
                "--------- Updated --------\n" +
                "Haly\n" +
                "© 2023-2024\n" +
                "--------- Contributors --------\n" +
                "Titan \n" +
                "Kleber Tomaz \n" +
                "Fulano \n" +
                "xDarK \n" +
                "--------- Created By --------\n" +
                "Kn1fe\n" +
                "Nes\n" +
                "© 2018\n" +
                "--------- Libraries --------\n" +
                "RodySoft (UdE API)\n" +
                "mbdavid (MadMilkman.Ini)\n" +
                "MahApps (MahApps.Metro, MahApps.Metro.IconsPacks)\n" +
                "SyncFusion\n" +
                "XAMLMarkupExtensions\n" +
                "WPFLocalizeExtension\n" +
                "zlib (Jean-loup Gailly and Mark Adler)\n" +
                "-----------------";

            // Display the message
            Utils.ShowMessage(message, "Aipolicy Editor", false);
        }



        //https://github.com/halysondev/AipolicyEditor
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
            var selectedItems = Controllers.SelectedItems;

            foreach (var item in selectedItems)
            {
                if (item is CPolicyData controller)
                {;
                    var clonedController = controller.Clone() as CPolicyData;
                    if (clonedController != null)
                    {
                        // Definir o novo ID do controlador clonado
                        clonedController.ID = Aipolicy.Controllers.Count > 0 ? Aipolicy.Controllers.Last().ID + 1 : 1;
                        Aipolicy.Controllers.Add(clonedController);
                    }

                }
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
            var selectedItems = Controllers.SelectedItems.Cast<CPolicyData>().ToList();

            foreach (var item in selectedItems)
            {
                Aipolicy.Controllers.Remove(item);
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

            Aipolicy.OnPropertyChanged("TriggerIndex");
            Aipolicy.OnPropertyChanged("CurrentTrigger");
            Aipolicy.OnPropertyChanged("CurrentOperations");
            Aipolicy.OnPropertyChanged("OperationsHeader");
        }

        private void CloneTrigger(object sender, RoutedEventArgs e)
        {
            var selectedItems = Triggers.SelectedItems.Cast<CTriggerData>().ToList();

            foreach (var item in selectedItems)
            {
                var clonedTrigger = item.Clone() as CTriggerData;
                if (clonedTrigger != null)
                {
                    clonedTrigger.ID = Aipolicy.CurrentTriggers.Count > 0 ? Aipolicy.CurrentTriggers.Last().ID + 1 : 0;
                    Aipolicy.CurrentTriggers.Add(clonedTrigger);
                }
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
            var selectedItems = Triggers.SelectedItems.Cast<CTriggerData>().ToList();

            foreach (var item in selectedItems)
            {
                Aipolicy.CurrentTriggers.Remove(item);
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
            var selectedItems = Operations.SelectedItems.Cast<IOperation>().ToList();

            foreach (var item in selectedItems)
            {
                Aipolicy.CurrentOperations.Add((item as ICloneable).Clone() as IOperation);
            }
        }


        private void AddOperation(object sender, RoutedEventArgs e)
        {
            OperationSelector os = new OperationSelector(Aipolicy.CurrentTrigger.Version);
            os.ShowDialog();
            if (os.Op != null)
            {
                Aipolicy.CurrentTrigger.Version = os.GetUpdatedVersion();
                Aipolicy.CurrentTrigger.Operations.Add(os.Op);
                Aipolicy.OnPropertyChanged("TriggerIndex");
                Aipolicy.OnPropertyChanged("CurrentTrigger");
                Aipolicy.OnPropertyChanged("CurrentOperations");
                Aipolicy.OnPropertyChanged("OperationsHeader");
            }
        }

        private void RemoveOperation(object sender, RoutedEventArgs e)
        {
            var selectedItems = Operations.SelectedItems.Cast<IOperation>().ToList();

            foreach (var item in selectedItems)
            {
                Aipolicy.CurrentTrigger.Operations.Remove(item);
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

        private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            Aipolicy.OnPropertyChanged("TriggerIndex");
            Aipolicy.OnPropertyChanged("CurrentTrigger");
            Aipolicy.OnPropertyChanged("CurrentOperations");
            Aipolicy.OnPropertyChanged("OperationsHeader");
        }

        private void NumericUpDown_ValueDecremented(object sender, NumericUpDownChangedRoutedEventArgs args)
        {
            Aipolicy.OnPropertyChanged("TriggerIndex");
            Aipolicy.OnPropertyChanged("CurrentTrigger");
            Aipolicy.OnPropertyChanged("CurrentOperations");
            Aipolicy.OnPropertyChanged("OperationsHeader");
        }

        private void NumericUpDown_ValueIncremented(object sender, NumericUpDownChangedRoutedEventArgs args)
        {
            Aipolicy.OnPropertyChanged("TriggerIndex");
            Aipolicy.OnPropertyChanged("CurrentTrigger");
            Aipolicy.OnPropertyChanged("CurrentOperations");
            Aipolicy.OnPropertyChanged("OperationsHeader");
        }
    }
}