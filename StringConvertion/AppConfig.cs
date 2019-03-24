using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StringConvertion.Domain.Interfaces;
using StringConvertion.Domain.Services;

namespace StringConvertion.ConsoleApp
{
    public class AppConfig
    {
        public static ServiceProvider ServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IStringService, StringService>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            return serviceProvider;
        }
    }
}
