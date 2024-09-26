using DCTCrypto.DataStorage;
using DCTCrypto.Models;
using DCTCrypto.Pages.CurrencyDetailsPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DCTCrypto.Pages.MainPage
{
    /// <summary>
    /// Interaction logic for MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Page
    {
        private readonly NavigationService _navigationService;
        private MainPageViewModel _viewModel;

        public MainPageView(IDataStorage dataStorage, NavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();
            _viewModel = new MainPageViewModel(dataStorage);
            DataContext = _viewModel;
            var view = (CollectionView)CollectionViewSource.GetDefaultView(_viewModel.Currencies);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription((nameof(CryptoCurrencyModel.Rank)),
                ListSortDirection.Ascending));
        }

        private void _currenciesListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _navigationService.Navigate(new CurrencyDetailsPageView(_viewModel.SelectedItem, _navigationService));
        }
    }
}
