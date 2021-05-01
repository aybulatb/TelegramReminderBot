using ReminderTelegramBot.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReminderTelegramBot.Model
{
    /// <summary>
    /// Хранилище напоминаний (временно, пока не подключил ДБ)
    /// </summary>
    public class RemindersStore : IReminderStore
    {
        private readonly List<Reminder> _reminders;
        public RemindersStore()
        {
            if (_reminders == null) _reminders = new List<Reminder>();
        }
        public void Set(Reminder reminder)
        {
            if (reminder != null && !_reminders.Contains(reminder))
                _reminders.Add(reminder);
        }
        public List<Reminder> GetAll() => _reminders;

        public void ClearAll()
        {
            if (_reminders.Any()) _reminders.Clear();
        }
    }
}
