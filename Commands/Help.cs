using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class Help : TelegramCommand
    {
        //todo Сделать отдельный метод GetKeyboardFor(string[] commands) который будет создавать кнопки
        public override string Name => "/help";
        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore)
        {
            var chatId = message.Chat.Id;

            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[] { 
                        new KeyboardButton("/help"), 
                        new KeyboardButton("/start"), 
                        new KeyboardButton("/напомнить"),
                        new KeyboardButton("/date"),
                        new KeyboardButton("/все записи")
                    }
                },
            };

            await client.SendTextMessageAsync(chatId, "Это бот-напоминатель. Скажи ему о чём тебе нужно напомнить, и он сделает это.");
            await client.SendTextMessageAsync(chatId, $"Список доступных команд", replyMarkup: keyBoard);
        }
    }
}
