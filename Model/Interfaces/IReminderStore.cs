using System.Collections.Generic;

namespace ReminderTelegramBot.Model.Interfaces
{
    public interface IReminderStore
    {
        void Set(Reminder reminder);
        List<Reminder> GetAll();
    }
}
