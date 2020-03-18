using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class Hello : TelegramCommand
    {
        public override string Name => "\U0001F3E0 Поздороваться";

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
                        new KeyboardButton("\U0001F451 Текст напоминания")
                    },
                    new []
                    {
                        new KeyboardButton("\U0001F45C Время напоминания")
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "Ну здорова, бродяга. Я твой бот, и в благородство играть не буду" +
                                                      "Нажмёшь на пару моих кнопок - и мы в расчёте.", 
                                                      ParseMode.Html, false, false, 0, keyBoard);
        }
    }
}
