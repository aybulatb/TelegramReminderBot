﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ReminderTelegramBot.Model;

namespace ReminderTelegramBot.Commands
{
    public class RemindDate : TelegramCommand
    {
        public override string Name => "/time";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var reminder = new Reminder();
            var remindTime = reminder.GetRemindTime(message.Text.Remove(Name.Length));

            await client.SendTextMessageAsync(chatId, $"Заказанное время {remindTime}, {reminder.GetTime()}", parseMode: ParseMode.Markdown);
            
            if (reminder.CheckTime()) 
            {
                await client.SendTextMessageAsync(chatId, $"Вовремя {remindTime}, {reminder.GetTime()}", parseMode: ParseMode.Markdown); 
            }
        }
    }
}
