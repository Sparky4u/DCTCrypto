using DCTCrypto.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DCTCrypto.Pages.CurrencyDetailsPage
{
    public partial class CurrencyDetailsPageView : Page
    {
        private readonly CurrencyDetailsPageViewModel _viewModel;

        public CurrencyDetailsPageView(CryptoCurrencyModel selectedCryptoCurrency, NavigationService navigationService)
        {
            InitializeComponent();
            _viewModel = new CurrencyDetailsPageViewModel(selectedCryptoCurrency, navigationService);
            DataContext = _viewModel;
        }
    }
}
