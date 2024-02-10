using Microsoft.Extensions.DependencyInjection;
using CRM.Application;
using CRM.Data;
using CRM.Domain;
using CRM.Application.Interfaces;
using CRM.Application.Services;
using CRM.Domain.Interfaces;
using CRM.Data.Repositories;
using CRM.Domain.Services;
using Storm.Tecnologia.Gov.Interfaces;
using Storm.Tecnologia.Gov.Services;
using CRM.Domain.Core.Notifications;
using Microsoft.AspNetCore.Http;
using CRM.Auth.Models;

namespace CRM.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region DomainCore
                services.AddSingleton<IDomainNotificationService, DomainNotificationService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPessoaService, PessoaService>();

            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IRegiaoService, RegiaoService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IMunicipioService, MunicipioService>();
            services.AddScoped<IPessoaEnderecoService, PessoaEnderecoService>();

            services.AddScoped<IControladorPessoaService, ControladorPessoaService>();
            services.AddScoped<IReceitawsService, ReceitawsService>();
            services.AddScoped<ILocalidadesService, LocalidadesService>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>();

            #endregion

            Constants.serviceProvider = services.BuildServiceProvider();
        }
    }
}
