using ReminderTelegramBot.Model;
using System;
using System.Text.RegularExpressions;

namespace ReminderTelegramBot
{
    public static class BotHelper
    {
        //public static void AddRemindToList(Reminder reminder)
        //{
            

        //}

        /// <summary>
        /// Ищет во входной строке время формата HH:mm
        /// </summary>
        public static DateTime AnalizeStringToDate(string text)
        {
            var regex = new Regex(@"([0-1]?[0-9]|2[0-3]):[0-5][0-9]");
            var match = regex.Match(text).Value;

            return DateTime.Parse(match);
        }
    }
}