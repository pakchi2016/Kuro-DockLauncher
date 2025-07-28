using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KuroDockLauncher.module
{
    public static class BookmarkButtonHandler
    {

        public static void BookmarkButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Process.Start(
                new ProcessStartInfo
                {
                    FileName = button.Tag.ToString(),
                    UseShellExecute = true
                }
            );
        }

        public  static void BookmarkButton_MouseOn(object sender, RoutedEventArgs e)
        {
            var mainwindow = Application.Current.MainWindow;
            if (mainwindow == null) { return; }
            var panel = mainwindow.FindName("FolderPulldown") as StackPanel;

            Button button = (Button)sender;
            panel.Children.Clear();
            foreach (string entry in Directory.EnumerateFileSystemEntries((string)button.Tag))
            {
                Button newButton = new Button
                {
                    Width = 90,
                    Height = 30,
                    Margin = new Thickness(0, 1, 0, 0),
                    Content = Path.GetFileName(entry),
                    Tag = entry
                };
                panel.Children.Add(newButton);
                newButton.Click += BookmarkButton_Click;

            }
        }
    }
}
