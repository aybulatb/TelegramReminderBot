using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                new Hello()
            };
        }
        public List<TelegramCommand> GetCommands()
        {
            return _commands;
        }
    }
}
