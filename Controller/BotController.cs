using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReminderTelegramBot.Model.Interfaces;
using Telegram.Bot.Types;

namespace ReminderTelegramBot.Controllers
{
    [ApiController]
    [Route("/api/message/update")]
    public class BotController : Controller
    {
        private readonly ICommandsService _telegramService;


        public BotController(ICommandsService telegramService)
        {
            _telegramService = telegramService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null)
                return Ok("update = null");

            await _telegramService.HandleUpdate(update);
            return Ok("update ok");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Bot is running");
        }
    }
}