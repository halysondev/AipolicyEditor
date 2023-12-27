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
            string[] files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lang"));
            foreach (string file in files)
            {
                Language.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
            Language.SelectedItem = Settings.Language;
            Configs.Text = Settings.ConfigsPath;
            Elements.Text = Settings.ElementsPath;
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
            if (Language.SelectedIndex > -1)
            {
                MainWindow.Provider.ChangeLanguage(Language.SelectedItem.ToString());
                Settings.Language = Language.SelectedItem.ToString();
                if (Type.IsChecked == true)
                    Settings.ConditionType = 1;
                else
                    Settings.ConditionType = 0;
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
