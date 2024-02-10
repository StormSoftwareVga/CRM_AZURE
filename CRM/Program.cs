using CRM;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

using CRM.Application;
using CRM.Application.ViewModels.Response;
using CRM.Auth.Models;
using CRM.Configurations;
using CRM.Data;
using CRM.IoC;
using CRM.Middlewares;
using CRM.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
    .UseSerilog((context, services, configuration) => configuration
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .MinimumLevel.Override("AspNetCore.HealthChecks.UI", LogEventLevel.Warning)
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .Enrich.WithMachineName()
    .Enrich.WithEnvironmentUserName()
    .Enrich.WithClientIp()
    .Enrich.WithCorrelationIdHeader("x-correlation-id")
    .Enrich.WithCorrelationId()
    .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
    .Filter.ByExcluding(c => c.Properties.Any(p => p.Value.ToString().Contains("/healthcheck")))
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} - {CorrelationId} {SystemOrigin}] {Message:lj}{NewLine}{Exception}"), writeToProviders: true);
}