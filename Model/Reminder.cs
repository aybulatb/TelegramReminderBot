using System;

namespace ReminderTelegramBot.Model
{
    /// <summary>
    /// Reminder object
    /// </summary>
    public class Reminder
    {
        public readonly int Id;

        private string Text { get; set; }

        private DateTime DateTime { get; set; }

        public Reminder(string text, DateTime dateTime)
        {
            Text = text;
            DateTime = dateTime;

            Id++;
        }
        public DateTime GetTime() => DateTime;

        public string GetText() => Text;

        //public bool CheckTime()
        //{
        //    while (DateTime.Now != DateTime)
        //    {
        //        CheckTime();
        //    }
        //    return true;
        //}
    }
}
