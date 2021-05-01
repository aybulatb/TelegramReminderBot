using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReminderTelegramBot.Model.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReminderTelegramBot.Controllers
{
    [ApiController]
    [Route("/api/message/update")]
    public class BotController : Controller
    {
        private readonly ICommandsService _telegramService;
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ILogger<BotController> _logger;
        private readonly IReminderStore _reminderStore;

        public BotController(ICommandsService telegramService,
            ITelegramBotClient telegramBotClient,
            ILogger<BotController> logger,
            IReminderStore reminderStore)
        {
            _telegramService = telegramService;
            _telegramBotClient = telegramBotClient;
            _logger = logger;
            _reminderStore = reminderStore;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null)
                return Ok("update = null");

            var commands = _telegramService.GetCommands();
            var message = update.Message;
            var callbackQuery = update.CallbackQuery;

            foreach (var command in commands)
            {
                if (command.Contains(message) || command.Contains(callbackQuery))
                {
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
            return Ok("update = ok");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Started test");
        }
    }
}