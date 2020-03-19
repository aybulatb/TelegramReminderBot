using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ReminderTelegramBot.Controllers
{
    [ApiController]
    [Route("/api/message/update")]
    public class BotController : Controller
    {
        private readonly ITelegramCommandsService _telegramService;
        private readonly ITelegramBotClient _telegramBotClient;
        public BotController(ITelegramCommandsService telegramService, ITelegramBotClient telegramBotClient)
        {
            _telegramService = telegramService;
            _telegramBotClient = telegramBotClient;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (update == null) 
                return Ok();

            var message = update.Message;

            foreach (var commands in _telegramService.GetCommands())
            {
                if (commands.Contains(message))
                {
                    await commands.Execute(message, _telegramBotClient);
                    break;
                }
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Started");
        }
    }
}