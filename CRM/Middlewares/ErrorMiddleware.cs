using CRM.Application.ViewModels.Response;
using CRM.Domain.Core.CrmException;
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
    }
}
