using System;
using System.Text.RegularExpressions;

namespace ReminderTelegramBot
{
    public static class BotHelper
    {
        /// <summary>
        /// Ищет во входной строке время формата HH:mm
        /// </summary>
        public static DateTime AnalizeStringToDate(string text)
        {
            var regex = new Regex(@"([0-1]?[0-9]|2[0-3]):[0-5][0-9]");
            string match = regex.Match(text).Value;

            var date = DateTime.Parse(match);

            if (DateTime.Now > date)
                return date.AddDays(1);

            return date;
        }
    }
}