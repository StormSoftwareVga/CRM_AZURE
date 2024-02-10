using CRM.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                var xmlPath =  "api-documentation.xml";
                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.OperationFilter<SwaggerProducesFilter>();
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            return app.UseSwagger().UseSwaggerUI(setupAction =>
            {
                setupAction.RoutePrefix = "swagger/ui";
                setupAction.SwaggerEndpoint("../../swagger/v1/swagger.json", "API v1");

                setupAction.OAuthClientId("swagger");
                setupAction.OAuthAppName("Swagger UI");

                setupAction.DefaultModelExpandDepth(2);
                setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                setupAction.EnableDeepLinking();
                setupAction.DisplayOperationId();
                 
            });
        }
    }

    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()
                            || context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                        Array.Empty<string>()
                    }
                }
            };
            }
        }
    }

    public class SwaggerProducesFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var responseCodes = new[] { "400", "401", "403", "404", "405", "406", "422", "423", "500", "504", "default" };

            foreach (var code in from code in responseCodes
                                 where operation.Responses.ContainsKey(code)
                                 select code)
            {
                operation.Responses[code].Content.Clear();
                operation.Responses[code].Content.Add("application/json; charset=utf-8", new OpenApiMediaType
                {
                    Schema = context.SchemaGenerator.GenerateSchema(typeof(Error), context.SchemaRepository),
                });
            }
        }
    }
}
