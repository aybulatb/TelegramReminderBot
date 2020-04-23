using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ReminderTelegramBot
{
    /// <summary>
    /// Reminder object
    /// </summary>
    public class Reminder
    {
        private string Text { get; set; }
        private DateTime DateTime { get; set; }
        /// <summary>
        /// Sets a description/text of remind
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetRemindText(string messageText)
        {
            Text = messageText;
            return Text;
        }
        /// <summary>
        /// Sets a time of remind
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// TODO: сделать так, что бы при любом сообщении(с буквами, с символами и тд) выбиралось только время(цифры) и записывались корректно
        public DateTime GetRemindTime(string messageText)
        {
            DateTime.TryParse(messageText, out DateTime remindTime);
            DateTime = remindTime;
            return remindTime;
        }
        
        public bool CheckTime()
        {
            var time = GetRemindTime(Text);
            while (DateTime.Now != time)
            {
                CheckTime();
            }
            return true;
        }
    }
}
