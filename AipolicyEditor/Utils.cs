using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WPFLocalizeExtension.Engine;
using Markdig;
using Markdig.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace AipolicyEditor
{
    public static class Utils
    {
        public static void MemoryCleaner()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void ShowMessage(string message, string title = "AipolicyEditor", bool isMarkdown = false)
        {
            if (isMarkdown)
            {
                // Create a MarkdownViewer to display Markdown content
                var markdownViewer = new MarkdownViewer
                {
                    Markdown = message,
                    Background = Brushes.White
                };

                var scrollViewer = new ScrollViewer
                {
                    Content = markdownViewer,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                    Background = Brushes.White
                };

                var window = new MetroWindow
                {
                    Title = title,
                    Height = 757,
                    Width = 513,
                    Content = scrollViewer,
                    Background = Brushes.White,
                    Foreground = Brushes.Black,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                window.ShowDialog();
            }
            else
            {
                ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync(title, message, MessageDialogStyle.Affirmative,
                new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok"
                });
            }
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
