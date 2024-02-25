using CRM.Application.ViewModels.Response;
using CRM.Domain.Core.CrmException;
using CRM.Domain.Core.Notifications;
using Microsoft.AspNetCore.Http; 
using System.Net;
using System.Text.Json;

namespace CRM.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);

                var code = context.Response.StatusCode;
                switch (code)
                {
                    case 401:
                        var unauthorizedMessage = "Cabeçalho de autenticação ausente/inválido ou token inválido";
                        var unauthorizedResponse = new Error(code.ToString(), unauthorizedMessage, unauthorizedMessage);
                        await WriteJsonResponseAsync(context, HttpStatusCode.Unauthorized, unauthorizedResponse);
                        break;
                    case 404:
                        var notFoundMessage = "O recurso solicitado não existe ou não foi implementado";
                        var notFoundResponse = new Error(code.ToString(), notFoundMessage, notFoundMessage);
                        await WriteJsonResponseAsync(context, HttpStatusCode.NotFound, notFoundResponse);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new ResponseViewModel();

  
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            { 
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Erro = ex.Message;                 
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Erro = "Internal Server Error";
            }

            if (ex is CRMNotificationException crmException)
            {
                response.Erro = crmException.Message;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            if(ex is System.ComponentModel.DataAnnotations.ValidationException)
            {
                response.Erro = ex.Message;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            var result = JsonSerializer.Serialize(response);
            context.Response.ContentType = "applicatin/json";
            return context.Response.WriteAsync(result);
        }

        private async Task WriteJsonResponseAsync(HttpContext context, HttpStatusCode statusCode, object responseObject)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = (int)statusCode;

            // Defina as configurações de serialização personalizadas
            var jsonSettings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var jsonResponse = JsonSerializer.Serialize(responseObject, jsonSettings);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
