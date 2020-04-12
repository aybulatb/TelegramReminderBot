﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class Hello : TelegramCommand
    {
        public override string Name { get; } = "Здарова";

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

            await client.SendTextMessageAsync(chatId, "Ну здорова, бродяга. Я твой бот, и в благородство играть не буду" +
                                                      "Нажмёшь на пару моих кнопок - и мы в расчёте.", 
                                                      parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}
