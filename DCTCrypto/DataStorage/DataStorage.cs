using DCTCrypto.Models;
using DynamicData;

namespace DCTCrypto.DataStorage
{
    public class DataStorage : IDataStorage
    {
        private readonly ISourceCache<CryptoCurrencyModel, string> _currenciesCache;

        public DataStorage()
        {
            _currenciesCache = new SourceCache<CryptoCurrencyModel, string>(x => x.Id);
        }

        public ISourceCache<CryptoCurrencyModel, string> CurrenciesCache => _currenciesCache;
    }
}
