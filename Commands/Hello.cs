using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class Hello : TelegramCommand
    {
        public override string Name => "/start";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore, CallbackQuery callbackQuery = null)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Ну здорова, бродяга. Я бот, и в благородство играть не буду. " +
                                                      "Нажмёшь на пару моих кнопок - и мы в расчёте. " +
                                                      "\nЧто бы увидеть список всех команд, введи: /help");
        }
    }
}
