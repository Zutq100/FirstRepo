using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using StorageWPF.Client.Services;
using StorageWPF.Client.ViewsModels;
using StorageWPF.Client.Views;
using System;
using System.Net.Http;
using System.Windows;

namespace StorageWPF
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<ApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddSingleton<ApiClient>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<ItemDetailViewModel>();
            services.AddTransient<ItemEditViewModel>();

            services.AddSingleton<MainWindow>();
            services.AddTransient<ItemsView>();
            services.AddTransient<ItemDetailsView>();
            services.AddTransient<ItemEditView>();
        }
    }

}
