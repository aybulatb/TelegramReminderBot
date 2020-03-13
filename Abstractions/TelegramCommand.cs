using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace ReminderTelegramBot
{
    public abstract class TelegramCommand
    {
        public abstract string Name { get; }
        public abstract Task Execute(MessageEventArgs e, TelegramBotClient client);
        public abstract bool Contains(Message message);
    }
}
