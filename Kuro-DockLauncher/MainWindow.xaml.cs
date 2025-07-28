using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using KuroDockLauncher.module;
using KuroDockLauncher.Property;
using System.Reflection;

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

            // タスクバーを除いたデスクトップ領域の情報を取得します
            var workArea = SystemParameters.WorkArea;

            // ウィンドウのサイズと位置を設定しますわ
            this.Height = workArea.Height;
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
                    if (Directory.Exists(item))
                    {
                        AddButtons.AddFolderButton(item);
                    }
                    else if (File.Exists(item))
                    {
                        AddButtons.AddFileButton(item);
                    }
                }
            }
        }
    }
}