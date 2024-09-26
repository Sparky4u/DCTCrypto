using DCTCrypto.DataStorage;
using System.Windows;
using DCTCrypto.Pages.MainPage;

namespace DCTCrypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IDataStorage dataStorage)
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new MainPageView(dataStorage, MainFrame.NavigationService));
        }
    }
}