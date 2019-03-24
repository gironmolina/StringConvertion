using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StringConvertion.Domain.Enums;
using StringConvertion.Domain.Interfaces;

namespace StringConvertion.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = AppConfig.ServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogDebug("Starting application");
            var stringService = serviceProvider.GetService<IStringService>();

            // This is just a test
            try
            {
                var text = "Hi- how are you?";
                stringService.GetSortedText(text, SortType.AlphabeticAsc);
                stringService.GetSortedText(text, SortType.AlphabeticDesc);
                stringService.GetSortedText(text, SortType.LengthAsc);
                stringService.GetTextStatistics(text);
                logger.LogDebug("All done!");
            }
            catch (Exception ex)
            {
                logger.LogError("", ex.Message);
                throw;
            }
        }
    }
}
