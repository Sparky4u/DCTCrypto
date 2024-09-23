using DCTCrypto.Models.Interfaces;
using DCTCrypto.Utilities;

namespace DCTCrypto.Models
{
    public class CryptoCurrencyModel : BaseNotifyPropertyChanged, IHaveId
    {
        private double? _changePercent24Hr;
        private string _id;
        private double? _marketCapUsd;
        private double? _maxSupply;
        private string _name;
        private double? _priceUsd;
        private int _rank;
        private double? _supply;
        private string _symbol;
        private double? _volumeUsd24Hr;
        private double? _vwap24Hr;

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public int Rank
        {
            get => _rank;
            set => SetProperty(ref _rank, value);
        }
        public string Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public double? ChangePercent24Hr
        {
            get => _changePercent24Hr;
            set => SetProperty(ref _changePercent24Hr, value);
        }
        public double? Supply
        {
            get => _supply;
            set => SetProperty(ref _supply, value);
        }
        public double? MaxSupply
        {
            get => _maxSupply;
            set => SetProperty(ref _maxSupply, value);
        }
        public double? MarketCapUsd
        {
            get => _marketCapUsd;
            set => SetProperty(ref _marketCapUsd, value);
        }
        public double? VolumeUsd24Hr
        {
            get => _volumeUsd24Hr;
            set => SetProperty(ref _volumeUsd24Hr, value);
        }

        public double? PriceUsd
        {
            get => _priceUsd;
            set => SetProperty(ref _priceUsd, value);
        }

        public double? Vwap24Hr
        {
            get => _vwap24Hr;
            set => SetProperty(ref _vwap24Hr, value);
        }
    }
}
