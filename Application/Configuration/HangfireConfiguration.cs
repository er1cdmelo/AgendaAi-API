using Hangfire;
using System.Diagnostics;

namespace Application.Configuration
{
    public class HangfireConfiguration
    {
        public static void ConfigureHangfire(IConfiguration configuration)
        {
            GlobalConfiguration.Configuration
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            // Define jobs recorrentes aqui
            RecurringJob.AddOrUpdate("Primeiro Serviço", () => Debug.WriteLine("Hello World!"), "35 19 * * *", new RecurringJobOptions()
            {
                TimeZone = TimeZoneInfo.Local
            });
        }
    }
}
