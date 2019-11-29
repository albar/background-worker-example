using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueExample.EventBus.Abstractions;
using QueueExample.EventBus.Windows;

namespace QueueExample.EventBus
{
    public class App
    {
        private IHost _host;

        public App()
        {
            _host = CreateHost().Build();
        }

        public async Task Start()
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetService<MainWindow>();
            var notificationWindow = _host.Services.GetService<NotificationWindow>();

            // open main window, hide notification window
        }

        public async Task Stop()
        {
            using (_host)
            {
                await _host.StopAsync();
            }
        }

        private IHostBuilder CreateHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureService);
        }

        private void ConfigureService(IServiceCollection services)
        {
            services.AddHostedService<NotificationService>();
            services.AddSingleton<IEventBus, NotificationEventBus>();
            // services.AddSingleton<IStorage, ??>() // implement the storage
            services.AddSingleton<MainWindow>();
            services.AddSingleton<NotificationWindow>();
        }
    }
}
