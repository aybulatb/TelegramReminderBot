using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ReminderTelegramBot.Model;

namespace ReminderTelegramBot.Commands
{
    public class SetRemind : TelegramCommand
    {
        public override string Name => "/напомнить";

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var text = new Reminder()
                .SetRemindText(message.Text.Remove(Name.Length));

            await client.SendTextMessageAsync(chatId, $"Окей, текст {text}", parseMode: ParseMode.Markdown);
        }
    }
}
