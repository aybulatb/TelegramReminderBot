using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReminderTelegramBot.Commands;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReminderTelegramBot.Services
{
    public class CommandsService : ICommandsService
    {
        private readonly List<TelegramCommand> _commands;
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ILogger<CommandsService> _logger;
        private readonly IReminderStore _reminderStore;

        public CommandsService(
            ITelegramBotClient telegramBotClient,
            ILogger<CommandsService> logger,
            IReminderStore reminderStore
        )
        {
            _telegramBotClient = telegramBotClient;
            _logger = logger;
            _reminderStore = reminderStore;

            _commands = new List<TelegramCommand>
            {
                new DateCommand(),
                new SetReminderCommand(),
                new HelloCommand(),
                new HelpCommand(),
                new GetAllRemindersCommand(),
                new ClearAllCommand()
            };
        }

        public List<TelegramCommand> GetCommands() => _commands;

        public async Task HandleUpdate(Update update)
        {
            var message = update.Message;
            var callbackQuery = update.CallbackQuery;

            foreach (var command in GetCommands())
            {
                if (!command.Contains(message) && !command.Contains(callbackQuery))
                    continue;

                try
                {
                    await command.Execute(message, _telegramBotClient, _reminderStore, callbackQuery);
                    _logger.LogInformation($"Command {command.Name} executed");
                }
                catch (System.Exception ex)
                {
                    _logger.LogError($"Ooops, some problems here: {ex.Message}");
                }
                break;
            }
        }
    }
}
