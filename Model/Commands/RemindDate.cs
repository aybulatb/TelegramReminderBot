using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class RemindDate : TelegramCommand
    {
        public override string Name => "/time";

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("/help")
                    }
                },
            };

            var remind = new Reminder();
            var remindTime = remind.GetRemindTime(message.Text.Remove(Name.Length));

            await client.SendTextMessageAsync(chatId, $"Время", parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}
