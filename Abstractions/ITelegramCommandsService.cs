using System.Collections.Generic;

namespace ReminderTelegramBot
{
    public interface ITelegramCommandsService
    {
        List<TelegramCommand> GetCommands();
    }
}
