using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReminderTelegramBot.Model.Interfaces;
using ReminderTelegramBot.Model;
using ReminderTelegramBot.Services;

namespace ReminderTelegramBot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICommandsService, CommandsService>()
                    .AddTelegramBotClient();

            services.AddSingleton<IReminderStore, RemindersStore>();

            services.AddControllers()
                    .AddNewtonsoftJson();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            { 
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
