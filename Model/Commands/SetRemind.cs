using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class SetRemind : TelegramCommand
    {
        public override string Name => "/напомнить";

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

            var remind1 = new Reminder();
            var text = remind1.SetRemindText(message.Text.Remove(Name.Length));

            await client.SendTextMessageAsync(chatId, $"Окей, текст {text}", parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}
