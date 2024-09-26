using DCTCrypto.DataStorage;
using DCTCrypto.Infrastructure.DataProcessors;
using DCTCrypto.Mapper;
using DCTCrypto.Models;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DCTCrypto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            MappingConfiguration.Configure();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services
                .AddSingleton<ISourceCache<CryptoCurrencyModel, string>,SourceCache<CryptoCurrencyModel,string>>();
            services.AddSingleton<IDataStorage, DataStorage.DataStorage>();
            services.AddSingleton<IDataProcessor<CryptoCurrencyModel>, CryptoCurrencyDataProcessor>();
        }
        
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            var cryptoCurrencyDataProcessor = _serviceProvider.GetService<IDataProcessor<CryptoCurrencyModel>>();
            mainWindow?.Show();
        }
    }

}
