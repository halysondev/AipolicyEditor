using AipolicyEditor.AIPolicy;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace AipolicyEditor
{
    public partial class SettingsWin : MetroWindow
    {
        public SettingsWin()
        {
            InitializeComponent();
            if (Settings.ConditionType == 1)
                Type.IsChecked = true;
            else
                Type.IsChecked = false;
            string[] files = Directory.GetFiles(Path.Combine(Utils.GetCurrentProcessFolder(), "Lang"));
            foreach (string file in files)
            {
                LanguageComboBox.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
            LanguageComboBox.SelectedItem = Settings.Language;
            Configs.Text = Settings.ConfigsPath;
            Elements.Text = Settings.ElementsPath;
            if(Settings.AuttomaticallyConvertToLastVersion == 1)
            {
                AutomaticConvertToLastVersionTrigger.IsChecked = true;
            }
            else
            {
                AutomaticConvertToLastVersionTrigger.IsChecked = false;
            }
        }

        private void ConfigsSelectClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Configs.Text = ofd.FileName;
            }
        }

        private void ElementsSelectClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Elements.Text = ofd.FileName;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (LanguageComboBox.SelectedIndex > -1)
            {
                MainWindow.Provider.ChangeLanguage(LanguageComboBox.SelectedItem.ToString());
                Settings.Language = LanguageComboBox.SelectedItem.ToString();
                if (Type.IsChecked == true)
                    Settings.ConditionType = 1;
                else
                    Settings.ConditionType = 0;

                if (AutomaticConvertToLastVersionTrigger.IsChecked == true)
                {
                    Settings.AuttomaticallyConvertToLastVersion = 1;
                }
                else
                {
                    Settings.AuttomaticallyConvertToLastVersion = 0;
                }

                if (Settings.ConfigsPath != Configs.Text || Settings.ElementsPath != Elements.Text)
                {
                    Reload(null, null);
                }

                
            }
            Close();
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            Settings.ConfigsPath = Configs.Text;
            Settings.ElementsPath = Elements.Text;
            CustomData.Init();
        }
    }
}
