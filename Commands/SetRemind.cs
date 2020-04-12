using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class SetRemind : TelegramCommand
    {
        public override string Name { get; } = "Напомнить";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message mes, ITelegramBotClient client)
        {
            var chatId = mes.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("Здарова")
                    },
                    new[]
                    {
                        new KeyboardButton("Напомнить")
                    },
                    new []
                    {
                        new KeyboardButton("Дата")
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "О чём вам напомнить?");

            Message message = new Message();
            string remindText = message.Text;

            if(remindText != null)
                await client.SendTextMessageAsync(chatId, $"Окей, {remindText}", 
                                                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
            else
                await client.SendTextMessageAsync(chatId, $"Вы ничего не ввели, попробуйте снова",
                                                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}
