using ReminderTelegramBot.Model.Interfaces;
using System.Collections.Generic;

namespace ReminderTelegramBot.Model
{
    /// <summary>
    /// Хранилище напоминаний (временно, пока не подключил ДБ)
    /// </summary>
    public class RemindersStore : IReminderStore
    {
        private readonly List<Reminder> _reminders;
        public void Set(Reminder reminder)
        {
            if(reminder != null)
                _reminders.Add(reminder);
        }

        public List<Reminder> GetAll()
        {
            return _reminders;
        }
    }
}
