using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using WPFLocalizeExtension.Providers;

namespace AipolicyEditor.Localization
{
    public class LocalizationProvider : FrameworkElement, ILocalizationProvider
    {
        private Dictionary<string, string> Translates = new Dictionary<string, string>();

        public ObservableCollection<CultureInfo> AvailableCultures
        {
            get
            {
                var c = new ObservableCollection<CultureInfo>();
                foreach (string t in Translates.Keys)
                {
                    c.Add(new CultureInfo(t));
                }
                return c;
            }
        }

        public event ProviderChangedEventHandler ProviderChanged;
        
#pragma warning disable CS0067 // The event is never used
        public event ProviderErrorEventHandler ProviderError;
        public event ValueChangedEventHandler ValueChanged;
#pragma warning restore CS0067

        public LocalizationProvider()
        {
            string[] files = Directory.GetFiles(Utils.GetCurrentProcessFolder(), "Lang");
            foreach (string file in files)
            {

            }
        }

        public void ChangeLanguage(string lang)
        {
            string[] files = Directory.GetFiles(Path.Combine(Utils.GetCurrentProcessFolder(), "Lang"), $"{lang}.*");
            if (files.Length < 1)
                return;
            StreamReader sr = new StreamReader(files.First());
            Translates.Clear();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Contains("="))
                {
                    var match = Regex.Matches(line, "\"([^\"]+)\"");
                    var split = line.Split('=');
                    if (!Translates.ContainsKey(split.First()) && match.Count > 0 && match[0].Groups.Count > 0)
                        Translates.Add(split.First(), match[0].Groups[1].Value);
                }
            }
            Utils.MemoryCleaner();
            ProviderChanged?.Invoke(this, new ProviderChangedEventArgs(null));
        }

        public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target)
        {
            if (Translates.ContainsKey(key))
                return new FQAssemblyDictionaryKey(Translates[key]);
            return new FQAssemblyDictionaryKey(key);
        }

        public object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
        {
            if (key == null)
                return key;
            if (Translates.ContainsKey(key))
                return Translates[key];
            return key;
        }

        public string GetLocalizedString(string key)
        {
            if (Translates.ContainsKey(key))
                return Translates[key];
            return null;
        }
    }
}
