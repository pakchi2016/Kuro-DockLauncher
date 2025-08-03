using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Kuro_DockLauncher;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using KuroDockLauncher.Property;


namespace KuroDockLauncher.module
{
    public static class AddButtons
    {

        public static void AddBookmarkButton(string item,StackPanel panel)
        {

            Button newbutton = new Button
            {
                Width = 90,
                Height = 30,
                Margin = new Thickness(0, 1, 0, 0),
                Tag = item,
                Content = Path.GetFileName(item),
            };

            if (Directory.Exists(item))
            {
                newbutton.MouseEnter += BookmarkButtonHandler.BookmarkButton_MouseOn;
            }
            newbutton.Click += BookmarkButtonHandler.BookmarkButton_Click;
            panel.Children.Add(newbutton);
        }

        public static void AddFileButton(string item,StackPanel panel)
        {
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
