using CRM;
using CRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CRM.Application.IntegrationTests
{
    public static class DbContextOptionsBuilderForTests
    {
        public static CRMDbContext ContextoDoBancoDeDados()
        {
            var connectionString = "Server=localhost;Database=CrmDesenvolvimento; Trusted_Connection=True;";
            var dbContextOptions = new DbContextOptionsBuilder<CRMDbContext>()
                .UseSqlServer(connectionString,
                    providerOptions =>
                    {
                        providerOptions.CommandTimeout(150000);
                    }).Options;
            var dbContext = new CRMDbContext(dbContextOptions);
            return dbContext;
        }
    }

    public static class IniciarTestes
    {
        public static IHostBuilder Start()
        {
            return Program.CreateHostBuilder(new string[] { });
        }
    }
}
