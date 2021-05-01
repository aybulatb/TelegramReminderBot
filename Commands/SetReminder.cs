using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class SetReminder : TelegramCommand
    {
        public override string Name => "/напомнить";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore, CallbackQuery callbackQuery = null)
        {
            var chatId = message.Chat.Id;
            var text = message.Text.Remove(0, Name.Length).Trim();

            if (!string.IsNullOrEmpty(text))
            {
                var date = BotHelper.AnalizeStringToDate(text);

                reminderStore.Set(new Reminder(text, date));

                await client.SendTextMessageAsync(chatId, $"Окей бро, напомню {text}, дата {date}");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Броо, а че напомнить то?");
                await client.SendTextMessageAsync(chatId, "введи /напомнить + свой текст с временем в формате 00:00");
            }
        }
    }
}
