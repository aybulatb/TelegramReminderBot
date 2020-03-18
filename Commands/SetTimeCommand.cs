using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace ReminderTelegramBot.Commands
{
    public class SetTimeCommand : TelegramCommand
    {
        public override string Name => "Время напоминания";

        public override bool Contains(Message message)
        {
            throw new NotImplementedException();
        }

        public override Task Execute(Message mes, ITelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
