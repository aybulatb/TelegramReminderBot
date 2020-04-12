using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace ReminderTelegramBot
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection, IConfiguration config)
        { 
            //var socksProxy = new HttpToSocks5Proxy(config["Socks5Host"], 80);
            var botClient = new TelegramBotClient(config["Token"]);
            var webHook = $"{config["Url"]}/api/message/update";

            
            botClient.SetWebhookAsync(webHook).Wait();

            return serviceCollection.AddTransient<ITelegramBotClient>(x => botClient);
        }
    }
}
