using DCTCrypto.Models;
using DynamicData;

namespace DCTCrypto.DataStorage
{
    public interface IDataStorage
    {
        ISourceCache<CryptoCurrencyModel, string> CurrenciesCache { get; }
    }
}
