using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class Hello : TelegramCommand
    {
        public override string Name => "/start";
        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[] {new KeyboardButton("/help")},
                    new[] {new KeyboardButton("/date")}
                },
            };
            await client.SendTextMessageAsync(chatId, "Ну здорова, бродяга. Я бот, и в благородство играть не буду. " +
                                                      "Нажмёшь на пару моих кнопок - и мы в расчёте.", 
                                                      parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}
