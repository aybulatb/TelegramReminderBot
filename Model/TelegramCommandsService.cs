using System.Collections.Generic;
using ReminderTelegramBot.Commands;

namespace ReminderTelegramBot.Services
{
    public class TelegramCommandsService : ITelegramCommandsService
    {
        private readonly List<TelegramCommand> _commands;
        public TelegramCommandsService()
        {
            _commands = new List<TelegramCommand>
            {
                new CheckDate(),
                new SetRemind(),
                new Hello(),
                new RemindDate(),
                new Help()
            };
        }
        public List<TelegramCommand> GetCommands()
        {
            return _commands;
        }
    }
}
