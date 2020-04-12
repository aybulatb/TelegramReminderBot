using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class CheckDate : TelegramCommand
    {
        public override string Name => "Дата";

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

            await client.SendTextMessageAsync(chatId, $"{DateTime.Now}", 
                                                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);

        }
    }
}
