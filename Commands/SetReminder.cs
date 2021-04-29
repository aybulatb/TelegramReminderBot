using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class SetReminder : TelegramCommand
    {
        public override string Name => "/напомнить";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore)
        {
            var chatId = message.Chat.Id;
            var text = message.Text.Remove(0, Name.Length - 1);
            var date = BotHelper.AnalizeStringToDate(text);

            reminderStore.Set(new Reminder(text, date));

            await client.SendTextMessageAsync(chatId, $"# Окей бро, текст {text}, дата {date}", parseMode: ParseMode.Markdown);
        }
    }
}
