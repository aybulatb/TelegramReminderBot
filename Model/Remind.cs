using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReminderTelegramBot
{
    /// <summary>
    /// Напоминание
    /// </summary>
    public class Remind
    {
        private string Text { get; set; }
        public Remind(string text)
        {
            Text = text;
        }
    }
}
