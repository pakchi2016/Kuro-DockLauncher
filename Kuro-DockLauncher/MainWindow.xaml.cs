using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace KuroDockLauncher
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double widthInPixels = 90;

            // タスクバーを除いたデスクトップ領域の情報を取得します
            var workArea = SystemParameters.WorkArea;

            // ウィンドウのサイズと位置を設定しますわ
            this.Height = workArea.Height;
            this.Width = widthInPixels;
            this.Top = workArea.Top;
            this.Left = workArea.Right - this.Width;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FileFolder_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ドロップされたファイルのパスを取得します
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var item in files)
                {
                    if (File.Exists(item))
                    {
                        Button newButton = new Button
                        {
                            Content = Path.GetFileName(item),
                            Width = 90,
                            Height = 30,
                            Margin = new Thickness(0,1,0,0),
                            Tag = item
                        };
                        FolderArea.Children.Add(newButton);
                        newButton.Click += BookmarkButton_Click;
                    }
                    else if(Directory.Exists(item))
                    {
                        Button newButton = new Button
                        {
                            Content = Path.GetFileName(item),
                            Width = 90,
                            Height = 30,
                            Margin = new Thickness(0, 1, 0, 0),
                            Tag = item
                        };
                        FileArea.Children.Add(newButton);
                        newButton.Click += BookmarkButton_Click;
                    }
                }
                
                
            }
        }

        private void BookmarkButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Process.Start(button.Tag.ToString());
        }
    }
}