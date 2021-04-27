using System.Collections.Generic;

namespace ReminderTelegramBot.Model.Interfaces
{
    public interface ICommandsService
    {
        List<TelegramCommand> GetCommands();
    }
}
