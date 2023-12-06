using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CRM.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger CRM - Storm",
                    Version = "v1",
                    Description = "Documentação do projeto CRM - Storm Software.",
                    Contact = new OpenApiContact
                    {
                        Name = "Storm Software",
                        Email = "desenvolvimento@stormsoftware.com.br",
                        Url = new Uri("https://stormsoftware.com.br")
                    }
                });

                var xmlPath =  "api-documentation.xml";
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("../../swagger/v1/swagger.json", "API v1");
            });
        }
    }
}
