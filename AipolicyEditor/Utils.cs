using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WPFLocalizeExtension.Engine;

namespace AipolicyEditor
{
    public static class Utils
    {
        public static void MemoryCleaner()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void ShowMessage(string message, string title = "AipolicyEditor")
        {
            ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync(title, message, MessageDialogStyle.Affirmative,
            new MetroDialogSettings()
            {
                AffirmativeButtonText = "Ok"
            });
        }

        public static List<uint> GetMask(uint value)
        {
            List<uint> list = new List<uint>();
            for (uint v = value; v != 0; v >>= 1)
            {
                list.Add(v & 1);
            }
            return list;
        }
    }
}
