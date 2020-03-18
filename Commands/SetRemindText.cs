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
        public override string Name => "\U0001F451 Напоминания";

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
                        new KeyboardButton("\U0001F3E0 Поздороваться")
                    },
                    new[]
                    {
                        new KeyboardButton("\U0001F451 Напоминания")
                    },
                    new []
                    {
                        new KeyboardButton("\U0001F45C Время напоминания")
                    }
                }
            };
            string remindText = mes.Text;

            await client.SendTextMessageAsync(chatId, $"Вы просили напомнить: {remindText}", ParseMode.Html, false, false, 0, keyBoard); 
        }
    }
}
