using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using MihaZupan;

namespace ReminderTelegramBot
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //var socksProxy = new HttpToSocks5Proxy("110.49.101.58", 1080);
            var client = new TelegramBotClient(configuration["Token"]);
            var webHook = $"{configuration["Url"]}/api/message/update";

            client.SetWebhookAsync(webHook).Wait();

            return serviceCollection.AddTransient<ITelegramBotClient>(x => client);
        }
    }
}
