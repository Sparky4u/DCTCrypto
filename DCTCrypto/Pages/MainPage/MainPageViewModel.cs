using DCTCrypto.DataStorage;
using DCTCrypto.Models;
using DCTCrypto.Utilities;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings.Extensions;
using DynamicData;
using System.Collections.ObjectModel;
namespace DCTCrypto.Pages.MainPage
{
    public class MainPageViewModel : BaseNotifyPropertyChanged, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly ObservableCollectionExtended<CryptoCurrencyModel> _currencies = new();

        public MainPageViewModel(IDataStorage dataStorage)
        {
            _compositeDisposable.Add(dataStorage.CurrenciesCache
                .Connect()
                .ObserveOnUIDispatcher()
                .Bind(_currencies)
                .Subscribe());
        }

        public ObservableCollection<CryptoCurrencyModel> Currencies => _currencies;
        public CryptoCurrencyModel SelectedItem { get; set; }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}
