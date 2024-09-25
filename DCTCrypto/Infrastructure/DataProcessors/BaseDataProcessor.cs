using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Timers;
using DCTCrypto.Constants;
using DCTCrypto.DataStorage;
using DCTCrypto.Models.Interfaces;
using DCTCrypto.Models.ResponseModel;
using DCTCrypto.Infrastructure.DataProcessors;
using DynamicData;
using Mapster;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;

namespace CryptoTracker.Infrastructure.DataProcessors
{
    public abstract class BaseDataProcessor<TModel, TResponseModel> : IDataProcessor<TModel>, IDisposable
        where TModel : class, IHaveId
        where TResponseModel : class, IHaveId, IResponseModel
    {
        private readonly IDataStorage _dataStorage;
        private HttpClient _httpClient = new();
        private string? _previousDataJson;
        private Timer _requestTimer;

        protected BaseDataProcessor(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
            SetupHttpRequestTimer(1000000);
        }

        protected IDataStorage DataStorage => _dataStorage;
        protected abstract string RequestUrl { get; }
        protected abstract int RefreshPeriodInMs { get; }

        public virtual void Dispose()
        {
            _httpClient.Dispose();
            _requestTimer.Dispose();
        }

        protected abstract ISourceCache<TModel, string> GetCache();

        protected void ProcessResponse(JsonElement data)
        {
            var receivedCurrencies = data.EnumerateArray()
                .Select(element => JsonConvert.DeserializeObject<TResponseModel>(element.GetRawText())).ToList();

            var cache = GetCache();

            cache.Edit(updater =>
            {
                var toRemove = updater.Items.Where(x => !receivedCurrencies.Any(y => y.Id.Equals(x.Id)))
                    .Select(x => x.Id).ToList();
                updater.Remove(toRemove);

                foreach (var updateData in receivedCurrencies)
                {
                    var exist = updater.Lookup(updateData.Id);

                    if (exist.HasValue)
                        updateData.Adapt(exist.Value);
                    else
                        updater.AddOrUpdate(updateData.Adapt<TModel>());
                }
            });
        }

        private void SetupHttpRequestTimer(int requestTimeoutInMs)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", Assembly.GetExecutingAssembly().GetName().Name);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "ed6d5023-722b-4f17-a248-2359c1479075");
            _httpClient.BaseAddress = new Uri(RequestUrls.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(requestTimeoutInMs);
            _requestTimer = new Timer(RefreshPeriodInMs);
            _requestTimer.Elapsed += OnHttpRequestTimerElapsed;
            _requestTimer.Start();
        }

        private async void OnHttpRequestTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                var response = await _httpClient.GetAsync(RequestUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonDocument = JsonDocument.Parse(responseBody);
                var root = jsonDocument.RootElement;
                var data = root.GetProperty("data");

                var currentDataJson = data.GetRawText();

                if (string.Equals(currentDataJson, _previousDataJson, StringComparison.Ordinal))
                    return;

                _previousDataJson = currentDataJson;
                ProcessResponse(data);
            }
            catch (HttpRequestException httpException)
            {
                //todo: add logging HttpExceptions
            }
        }
    }
}