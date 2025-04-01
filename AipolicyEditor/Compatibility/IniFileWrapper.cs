using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Text;

namespace AipolicyEditor.Compatibility
{
    /// <summary>
    /// Implementação moderna de manipulação de arquivos INI para substituir o MadMilkman.Ini
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class IniFileWrapper
    {
        private readonly Dictionary<string, Dictionary<string, string>> _sections = new Dictionary<string, Dictionary<string, string>>();
        private readonly string _filePath;

        public IniFileWrapper(string filePath)
        {
            _filePath = filePath;
            if (File.Exists(filePath))
            {
                Load();
            }
        }

        /// <summary>
        /// Carrega o arquivo INI
        /// </summary>
        public void Load()
        {
            _sections.Clear();
            
            string currentSection = null;
            Dictionary<string, string> currentDictionary = null;

            foreach (var line in File.ReadAllLines(_filePath))
            {
                string trimmedLine = line.Trim();
                
                // Pular linhas vazias e comentários
                if (string.IsNullOrWhiteSpace(trimmedLine) || trimmedLine.StartsWith(";") || trimmedLine.StartsWith("#"))
                    continue;

                // Tratar seções [Section]
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    if (!_sections.TryGetValue(currentSection, out currentDictionary))
                    {
                        currentDictionary = new Dictionary<string, string>();
                        _sections[currentSection] = currentDictionary;
                    }
                    continue;
                }

                // Tratar entradas key=value
                int indexOfEquals = trimmedLine.IndexOf('=');
                if (indexOfEquals > 0 && currentDictionary != null)
                {
                    string key = trimmedLine.Substring(0, indexOfEquals).Trim();
                    string value = trimmedLine.Substring(indexOfEquals + 1).Trim();
                    
                    // Remover aspas, se presentes
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                        value = value.Substring(1, value.Length - 2);
                    
                    currentDictionary[key] = value;
                }
            }
        }

        /// <summary>
        /// Salva o arquivo INI
        /// </summary>
        public void Save()
        {
            using (var writer = new StreamWriter(_filePath, false, Encoding.UTF8))
            {
                foreach (var section in _sections)
                {
                    writer.WriteLine($"[{section.Key}]");
                    
                    foreach (var entry in section.Value)
                    {
                        writer.WriteLine($"{entry.Key}={entry.Value}");
                    }
                    
                    writer.WriteLine(); // Linha em branco entre seções
                }
            }
        }

        /// <summary>
        /// Obtém um valor do arquivo INI
        /// </summary>
        public string GetValue(string section, string key, string defaultValue = "")
        {
            if (_sections.TryGetValue(section, out var sectionDict))
            {
                if (sectionDict.TryGetValue(key, out var value))
                {
                    return value;
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// Define um valor no arquivo INI
        /// </summary>
        public void SetValue(string section, string key, string value)
        {
            if (!_sections.TryGetValue(section, out var sectionDict))
            {
                sectionDict = new Dictionary<string, string>();
                _sections[section] = sectionDict;
            }
            
            sectionDict[key] = value;
        }
    }
} 