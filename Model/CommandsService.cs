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
