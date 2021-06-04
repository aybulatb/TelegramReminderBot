using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ReminderTelegramBot.Model.Interfaces
{
    public interface ICommandsService
    {
        /// <summary>
        /// Возвращает список комманд, которые следуют общему интерфейсу.
        /// </summary>
        /// <returns></returns>
        List<TelegramCommand> GetCommands();

        Task HandleUpdate(Update update);
    }
}
