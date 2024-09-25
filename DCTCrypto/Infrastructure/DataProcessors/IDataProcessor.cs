using DCTCrypto.Models.Interfaces;

namespace DCTCrypto.Infrastructure.DataProcessors
{
    public interface IDataProcessor<TModel>
        where TModel : class,IHaveId
    {
    }
}
