using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReminderTelegramBot
{
    public abstract class TelegramCommand
    {
        public abstract string Name { get; }
        public abstract Task Execute(Message mes, ITelegramBotClient client);
        public abstract bool Contains(Message message);
    }
}
