using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Runtime.InteropServices;
using CRM.Domain.Core.Notifications;

namespace CRM.Domain.Core.CrmException
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context">context</param>
        public override void OnException(ExceptionContext context)
        {
            var codigo = Marshal.GetExceptionPointers().ToString();
            var messagem = context.Exception.Message;
            var rastreamento = context.Exception.StackTrace;

            if (context.Exception is BusinessException)
            {
                Log.Information("[BusinessException] " + messagem);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
                context.Result = new JsonResult(new Error(codigo, messagem, rastreamento));
            }
            else
            {
                Log.Error("[Exception] " + messagem);

                var portalExeception = context.Exception.GetType().GetProperty("Causas");

                if (portalExeception?.PropertyType.Name == "PortalHttpExceptionInfo[]")
                {
                    codigo = ((int)HttpStatusCode.BadRequest).ToString();
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
                    context.Result = new JsonResult(new Error(codigo, messagem, rastreamento));
                }

                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
                    context.Result = new JsonResult(new Error(context.HttpContext.Response.StatusCode.ToString(), messagem, rastreamento));
                }

                base.OnException(context);
            }
        }
    }
}
