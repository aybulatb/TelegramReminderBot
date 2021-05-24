using ReminderTelegramBot.Model;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class GetAllRemindersCommand : TelegramCommand
    {
        public override string Name => "все записи";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore, CallbackQuery callbackQuery = null)
        {
            string reminders = "";
            foreach (var item in reminderStore.GetAll())
            {
                reminders += item.GetText() + "\n";
            }

            if (string.IsNullOrEmpty(reminders))
                await client.SendTextMessageAsync(message.Chat.Id, "Записей нет...");

            await client.SendTextMessageAsync(message.Chat.Id, reminders);
        }
    }
}
