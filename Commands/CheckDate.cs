using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using ReminderTelegramBot.Model;

namespace ReminderTelegramBot.Commands
{
    /// <summary>
    /// Самая обычная команда, возвращающая время сейчас
    /// </summary>
    public class CheckDate : TelegramCommand
    {
        public override string Name => "/date";

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[] { new KeyboardButton("/help") }
                },
            };
            await client.SendTextMessageAsync(chatId, $"{DateTime.Now:F}",
                                                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}
