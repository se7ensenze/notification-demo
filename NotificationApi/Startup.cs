using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace NotificationApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();
            services.AddCors(setup =>
                setup.AddDefaultPolicy(cfg =>
                    cfg.WithOrigins("https://localhost:44337")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()));

            services.AddSingleton<Infrastructure.Hubs.NotificationHubManager>();
            services.AddSingleton<Infrastructure.Hubs.ConnectionManager>();

            services.AddTransient<Process.PushNotification.IPushNotificationRepository, 
                Infrastructure.Repositories.PushNotificationRepository>();
            services.AddTransient<Process.PushNotification.IPushNotificationManager,
                Process.PushNotification.v1.PushNotificationManager>();

            services.AddTransient<Process.ListNotification.IListNotificationRepository,
                Infrastructure.Repositories.ListNotificationRepository>();
            services.AddTransient<Process.ListNotification.IListNotificationManager,
                Process.ListNotification.v1.ListNotificationManager>();

            services.AddScoped<Infrastructure.Repositories.NotificationDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<Infrastructure.Hubs.NotificationHub>("/notification-hub");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Notification API V1");
            });
        }
    }
}
