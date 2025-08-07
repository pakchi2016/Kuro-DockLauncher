using KuroDockLauncher.Index;
using KuroDockLauncher.module;
using KuroDockLauncher.Property;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var indexdoc = new IndexControl();
            indexdoc.ShowDialog();
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearPanel(object sender, MouseEventArgs e)
        {
            MiddlePanel.Children.Clear();
            FolderPulldown.Children.Clear();
        }
    }
}