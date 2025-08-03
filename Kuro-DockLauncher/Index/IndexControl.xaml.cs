using KuroDockLauncher.module;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KuroDockLauncher.Index
{
    /// <summary>
    /// IndexControl.xaml の相互作用ロジック
    /// </summary>
    public partial class IndexControl : Window
    {
        public IndexControl()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var mainwindow = Application.Current.MainWindow;
            if (mainwindow == null) { return; }
            var panel = mainwindow.FindName("IndexPanel") as StackPanel;
            var middlePanel = mainwindow.FindName("MiddlePanel") as StackPanel;

            string indexName = IndexNameTextBox.Text.Trim();
            Button IndexButton = new Button
            {
                Width = 90,
                Height = 30,
                Margin = new Thickness(0, 1, 0, 0),
                Content = indexName
            };
            IndexButton.AllowDrop = true;
            IndexButton.Drop += Bookmark_Drop;
            IndexButton.MouseEnter += Bookmark_View;
            panel.Children.Add(IndexButton);


            this.DialogResult = true; // ダイアログを閉じて、OKが選択されたことを示す
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true; // ダイアログを閉じて、OKが選択されたことを示す
            this.Close();
        }

        private void Bookmark_Drop(object sender, DragEventArgs e)
        {
            Button button = (Button)sender;
            List<string> pathList = new List<string>(); // Initialize the variable to fix CS0165
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    if (System.IO.Directory.Exists(file) || System.IO.File.Exists(file))
                    {
                        // フォルダの場合の処理
                        pathList.Add(file);
                    }
                }
                if (pathList != null) { button.Tag = pathList; };
            }
            
        }

        private void Bookmark_View(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) {return;}
            if (sender is Button indexButton && indexButton.Tag is List<string> pathList)
            {
                if (pathList.Count == 0) { return; }
                var panel = Application.Current.MainWindow.FindName("MiddlePanel") as StackPanel;
                var sidepanel = Application.Current.MainWindow.FindName("FolderPulldown") as StackPanel;

                if (panel == null) { return; }

                panel.Children.Clear();
                sidepanel.Children.Clear();
                foreach (string entry in pathList)
                {
                    AddButtons.AddBookmarkButton(entry, panel);
                }
            }
        }


    }
}
