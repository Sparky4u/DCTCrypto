using DCTCrypto.Models;
using DCTCrypto.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DCTCrypto.Pages.CurrencyDetailsPage
{
    public class CurrencyDetailsPageViewModel : BasePageViewModel
    {
        private ICommand _goBackCommand;

        public CurrencyDetailsPageViewModel(CryptoCurrencyModel model,NavigationService navigationService) : base(navigationService)
        {
           Model = model;
        }

        public CryptoCurrencyModel Model { get; }
    }
}
