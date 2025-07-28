using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Kuro_DockLauncher;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using KuroDockLauncher.module;
using KuroDockLauncher.Property;


namespace KuroDockLauncher.module
{
    public static class AddButtons
    {

        public static void AddFolderButton(string item)
        {
            var mainwindow = Application.Current.MainWindow;
            if (mainwindow == null) { return; }
            var panel = mainwindow.FindName("FolderPanel") as StackPanel;

            Button newbutton = new Button
            {
                Width = 90,
                Height = 30,
                Margin = new Thickness(0, 1, 0, 0),
                Tag = item,
                Content = Path.GetFileName(item),
            };
            panel.Children.Add(newbutton);
            newbutton.Click += BookmarkButtonHandler.BookmarkButton_Click;
            newbutton.MouseEnter += BookmarkButtonHandler.BookmarkButton_MouseOn;
        }

        public static void AddFileButton(string item)
        {
            var mainwindow = Application.Current.MainWindow;
            if (mainwindow == null) { return; }
            var panel = mainwindow.FindName("FilePanel") as StackPanel;

            Button newbutton = new Button
            {
                Width = 90,
                Height = 30,
                Margin = new Thickness(0, 1, 0, 0),
                Tag = item,
                Content = Path.GetFileName(item),
            };
            panel.Children.Add(newbutton);
            newbutton.Click += BookmarkButtonHandler.BookmarkButton_Click;
        }
    }
}
