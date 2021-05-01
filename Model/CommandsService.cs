using System.Collections.Generic;
using ReminderTelegramBot.Commands;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Model
{
    public class CommandsService : ICommandsService
    {
        private readonly List<TelegramCommand> _commands;
        public CommandsService()
        {
            _commands = new List<TelegramCommand>
            {
                new CheckDate(),
                new SetReminder(),
                new Hello(),
                new Help(),
                new GetAllReminders(),
                new ClearAll()
            };
        }
        public List<TelegramCommand> GetCommands()
        {
            return _commands;
        }
    }
}
