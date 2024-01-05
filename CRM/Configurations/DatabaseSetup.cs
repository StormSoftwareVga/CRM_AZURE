using CRM.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceProvider serviceProvicer)
        {
            if (serviceProvicer == null) throw new ArgumentNullException(nameof(serviceProvicer));

            using (var scope = serviceProvicer.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbContext = services.GetRequiredService<CRMDbContext>();
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                }
            }

        }
    }
}
