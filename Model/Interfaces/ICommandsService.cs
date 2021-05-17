using System.Collections.Generic;

namespace ReminderTelegramBot.Model.Interfaces
{
    public interface ICommandsService
    {
        /// <summary>
        /// Возвращает список комманд, которые следуют общему интерфейсу. (Паттерн фабричный метод)
        /// </summary>
        /// <returns></returns>
        List<TelegramCommand> GetCommands();
    }
}
