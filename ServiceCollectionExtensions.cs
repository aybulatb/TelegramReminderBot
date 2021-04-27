using Microsoft.Extensions.DependencyInjection;
using System;
using Telegram.Bot;

namespace ReminderTelegramBot
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection)
        {
            var token = Environment.GetEnvironmentVariable("BOT_TOKEN");
            var url = Environment.GetEnvironmentVariable("BOT_URL");

            var botClient = new TelegramBotClient(token);
            var webHook = $"{url}/api/message/update";
            
            botClient.SetWebhookAsync(webHook).Wait();

            return serviceCollection.AddTransient<ITelegramBotClient>(x => botClient);
        }
    }
}
