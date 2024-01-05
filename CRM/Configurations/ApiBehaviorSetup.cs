using CRM.Application.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRM.Configurations
{
    public static class ApiBehaviorSetup
    {
        public static void AddApiBehaviorSetup(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.InvalidModelStateResponseFactory = context =>
                {
                    var erros = context.ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList());

                    var errorResponse = new ResponseViewModel()
                    {
                        Sucesso = false,
                        Dados = null,
                        Erro = JsonSerializer.Serialize(erros.SelectMany(x => x.Value))
                    };

                    var result = new BadRequestObjectResult(errorResponse);
                    result.ContentTypes.Add("application/problem+json");

                    return result;
                };
            });
        }
    }
}
