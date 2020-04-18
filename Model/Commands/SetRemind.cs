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

            var text = message.Text.Remove(0, Name.Length);
            var remind = new Remind(text);

            await client.SendTextMessageAsync(chatId, $"Окей, ", parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}
