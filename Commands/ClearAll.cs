using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Commands
{
    public class ClearAll : TelegramCommand
    {
        public override string Name => "удалить все";

        public override async Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore, CallbackQuery callbackQuery = null)
        {
            if (message != null)
            {
                var keyBoard = new InlineKeyboardMarkup(new[]
                    {
                        new InlineKeyboardButton{ Text = "Да", CallbackData = "yes" },
                        new InlineKeyboardButton{ Text = "Нет, не надо", CallbackData = "no" }
                    });

                await client.SendTextMessageAsync(message.Chat.Id, "Точно удалить все напоминания?", replyMarkup: keyBoard);
            }

            if (callbackQuery != null)
            {
                if (callbackQuery.Data.Equals("yes"))
                {
                    reminderStore.ClearAll();
                    await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "пиу пиу пиу");
                }
                else
                    await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Окей, не буду");
            }
        }
    }
}
