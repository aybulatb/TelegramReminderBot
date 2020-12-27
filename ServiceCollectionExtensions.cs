using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace ReminderTelegramBot
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection, IConfiguration config)
        { 
            var botClient = new TelegramBotClient(config["Token"]);
            var webHook = $"{config["Url"]}/api/message/update";
            
            botClient.SetWebhookAsync(webHook).Wait();

            return serviceCollection.AddTransient<ITelegramBotClient>(x => botClient);
        }
    }
}
