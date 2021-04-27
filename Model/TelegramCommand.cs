using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ReminderTelegramBot.Model
{
    public abstract class TelegramCommand
    {
        public abstract string Name { get; }
        public abstract Task Execute(Message message, ITelegramBotClient client);
        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }
    }
}
