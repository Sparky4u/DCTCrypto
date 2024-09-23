using DCTCrypto.Models;
using DCTCrypto.Models.ResponseModel;
using Mapster;
using System.Globalization;

namespace DCTCrypto.Mapper
{
    public class MappingConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<CryptoCurrencyResponseModel, CryptoCurrencyModel>
                .NewConfig()
                .Ignore(x => x.Rank)
                .Ignore(x => x.Supply)
                .Ignore(x => x.MaxSupply)
                .Ignore(x => x.MarketCapUsd)
                .Ignore(x => x.VolumeUsd24Hr)
                .Ignore(x => x.PriceUsd)
                .Ignore(x => x.ChangePercent24Hr)
                .Ignore(x => x.Vwap24Hr)
                .AfterMapping((src, dest) =>
                {
                    dest.Rank = int.Parse(src.Rank);
                    dest.Supply = double.TryParse(src.Supply, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedSupply)
                        ? parsedSupply
                        : null;
                    dest.MaxSupply = double.TryParse(src.MaxSupply, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedMaxSupply)
                        ? parsedMaxSupply
                        : null;
                    dest.MarketCapUsd = double.TryParse(src.MarketCapUsd, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedMarketCap)
                        ? parsedMarketCap
                        : null;
                    dest.VolumeUsd24Hr = double.TryParse(src.VolumeUsd24Hr, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedVolume)
                        ? parsedVolume
                        : null;
                    dest.PriceUsd = double.TryParse(src.PriceUsd, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedPrice)
                        ? parsedPrice
                        : null;
                    dest.ChangePercent24Hr = double.TryParse(src.ChangePercent24Hr, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedChange)
                        ? parsedChange
                        : null;
                    dest.Vwap24Hr = double.TryParse(src.Vwap24Hr, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedVwap)
                        ? parsedVwap
                        : null;
                });
                


        }
    }
}
