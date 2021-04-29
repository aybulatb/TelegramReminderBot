using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    /// <summary>
    /// Самая обычная команда, возвращающая время сейчас
    /// </summary>
    public class CheckDate : TelegramCommand
    {
        public override string Name => "/date";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore)
        {
            var chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId, $"{DateTime.Now:F}", parseMode: ParseMode.Markdown);
        }
    }
}
