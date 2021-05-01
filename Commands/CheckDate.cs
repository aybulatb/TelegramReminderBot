using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    /// <summary>
    /// Самая обычная команда, возвращающая время сейчас
    /// </summary>
    public class CheckDate : TelegramCommand
    {
        public override string Name => "/дата";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore, CallbackQuery callbackQuery = null)
        {
            var chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId, $"{DateTime.Now:F}");
        }
    }
}
