using CryptoTracker.Infrastructure.DataProcessors;
using DCTCrypto.Constants;
using DCTCrypto.DataStorage;
using DCTCrypto.Models;
using DCTCrypto.Models.ResponseModel;
using DynamicData;

namespace DCTCrypto.Infrastructure.DataProcessors
{
    public class CryptoCurrencyDataProcessor : BaseDataProcessor<CryptoCurrencyModel,CryptoCurrencyResponseModel>
    {
        public CryptoCurrencyDataProcessor(IDataStorage dataStorage) : base(dataStorage)
        {
        }

        protected override string RequestUrl => RequestUrls.AssetsUrl;
        protected override int RefreshPeriodInMs => 1000;
        protected override ISourceCache<CryptoCurrencyModel,string> GetCache() => DataStorage.CurrenciesCache;
    }
}
