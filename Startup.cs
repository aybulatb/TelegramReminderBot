using System;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using ReminderTelegramBot.Services;

namespace ReminderTelegramBot
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITelegramCommandsService, TelegramCommandsService>()
                    .AddTelegramBotClient(_configuration)
                    .AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    })
                    .AddFluentValidation();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
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
