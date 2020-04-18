using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReminderTelegramBot.Commands
{
    public class Help : TelegramCommand
    {
        public override string Name => "/help";

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, $"Список команд:\r\n1./напомнить + \"ваш текст напоминания\"" +
                                                                    $"\r\n2./date - узнать дату и время" +
                                                                    $"\r\n3./что нибудь ещё...");
            await client.SendTextMessageAsync(chatId, "Это бот-напоминатель. Скажи ему о чём тебе нужно напомнить, и он сделает это.");
        }
    }
}
