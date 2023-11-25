using Microsoft.Extensions.DependencyInjection;
using CRM.Application;
using CRM.Data;
using CRM.Domain;

namespace CRM.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }
    }
}
