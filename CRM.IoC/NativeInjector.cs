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

            //services.AddScoped<IVariacaoService, VariacaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IYahooFinanceService, YahooFinanceService>();

            #endregion

            #region Repositories

            //services.AddScoped<IVariacaoRepository, VariacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region Business

            //services.AddScoped<IVariacaoBusiness, VariacaoBusiness>();

            #endregion

        }
    }
}
