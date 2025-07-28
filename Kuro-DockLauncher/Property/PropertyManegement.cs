using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization; 

namespace KuroDockLauncher.Property
{
    public partial class PM : ObservableObject
    {
        // シングルトン実装
        private static readonly PM _instance = new();
        public static PM Instance => _instance;
        private PM() { }

        // プロパティの定義
        [ObservableProperty] private string _FilePath;

    }
}
