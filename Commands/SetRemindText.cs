using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class SetRemindText : TelegramCommand
    {
        public override string Name => "Текст напоминания";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e.Message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("\U0001F3E0 Поздороваться")
                    },
                    new[]
                    {
                        new KeyboardButton("\U0001F451 Текст напоминания")
                    },
                    new []
                    {
                        new KeyboardButton("\U0001F45C Время напоминания")
                    }
                }
            };
            string remindText = e.Message.Text;

            await client.SendTextMessageAsync(chatId, $"Вы просили напомнить: {remindText}", ParseMode.Html, false, false, 0, keyBoard); 
        }
    }
}
