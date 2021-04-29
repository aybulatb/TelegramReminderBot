﻿using ReminderTelegramBot.Model;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class GetAllReminders : TelegramCommand
    {
        public override string Name => "/все записи";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore)
        {
            string reminders = "";
            foreach (var item in reminderStore.GetAll())
            {
                reminders += item.GetText() + "\n";
            }

            await client.SendTextMessageAsync(message.Chat.Id, reminders);
        }
    }
}