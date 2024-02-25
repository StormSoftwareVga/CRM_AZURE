using CRM.Application;
using CRM.Data;
using CRM.Domain.Core.CrmException;
using CRM.Domain.Core.Notifications;
using CRM.IoC;
using CRM.Swagger;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using CRM.Application.ViewModels;
using CRM.Auth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CRM.Configurations;
using CRM.Middlewares;

namespace CRM
{
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// StartUp
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           .AddEnvironmentVariables();
            Configuration = builder.Build();

            //Serilog para Log            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(string.Concat(env.ContentRootPath, $@"\logs\datalog-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.txt"), retainedFileCountLimit: 10)
                .CreateLogger();
            CRM.Domain.Core.Log.Register(Log.Logger);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ApiExceptionFilter());//Tratamento das Exceptions
            });

            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapperSetup));

            //Configure Key Configs
            services.Configure<KeysConfig>(Configuration);

            //Lendo chaves no arquivo de configuracoes
            services.AddOptions();

            //Injecao de dependencia nativa
            NativeInjector.RegisterServices(services);

            //Adicionar a compressão ao servico
            services.AddResponseCompression();

            //Adicionar http context
            services.AddHttpContextAccessor();

            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
            });

            //Contexto MSSQL Entity Framework Core
            services.AddDbContext<CRMDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CrmDB"),
            providerOptions =>
            {
                providerOptions.CommandTimeout(150000);
            }), ServiceLifetime.Transient);

            //Swagger configuration
            services.AddSwaggerConfiguration();

            //Configure producer
            services.AddMvc(options =>
            {
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 400));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 401));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 403));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 404));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 405));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 406));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 422));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 423));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 429));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 500));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 504));
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(Error), 529));
            });

            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields =
                HttpLoggingFields.RequestPropertiesAndHeaders |
                HttpLoggingFields.RequestBody |
                HttpLoggingFields.RequestQuery |
                HttpLoggingFields.RequestMethod |
                HttpLoggingFields.RequestProtocol |
                HttpLoggingFields.RequestPath |
                HttpLoggingFields.ResponseBody |
                HttpLoggingFields.ResponseHeaders |
                HttpLoggingFields.ResponsePropertiesAndHeaders |
                HttpLoggingFields.ResponseStatusCode;
                logging.RequestHeaders.Add("x-web-key");
            });


            //STORM 
            services.AddApiBehaviorSetup();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader();


                    //.WithOrigins("http://localhost:4200")  // Adicione aqui o seu domínio Angular
                });
            });

            var chave = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSerilogRequestLogging(options =>
            {
                // Customize the message template
                options.MessageTemplate = "Handled {RequestPath} Status {StatusCode} RequestMethod {RequestMethod} Elapsed {Elapsed}";

                // Emit debug-level events instead of the defaults
                //options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

                // Attach additional properties to the request completion event
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                    diagnosticContext.Set("ResponseStatus", httpContext.Response.StatusCode);
                    diagnosticContext.Set("RequestMethod", httpContext.Request.Method);
                    diagnosticContext.Set("RequestPath", httpContext.Request.Path);
                };
            });

            app.UseMiddleware(typeof(ErrorMiddleware));

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Serilog para Log
            var _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConfiguration((IConfiguration)Configuration.GetSection("Logging"));
                builder.AddSerilog();
                builder.AddDebug();
            });

            app.ApplicationServices.AddDatabaseSetup();

            //loggerFactory = _loggerFactory;

            app.UseSwaggerConfiguration(env);

            //Adicionar a compressão ao servico
            app.UseResponseCompression();
        }
    }
}
