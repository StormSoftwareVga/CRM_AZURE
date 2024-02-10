using CRM.Application.ViewModels.Response;
using CRM.Domain.Core.Notifications;
using CRM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net;
using System.Text.Json; 

namespace CRM
{
    public abstract class BaseController : ControllerBase
    {
        public BaseController() 
        {
        }

        protected IActionResult Paginate<T>(IEnumerable<T> data, int? page = 1, int? pageSize = 25) where T : class
        {
            var paginatedData = data.ResultadoSearch(page, pageSize);
            return Ok(paginatedData);
        }

        public IActionResult Ok<T>(IEnumerable<T> value, int? page = 1, int? pageSize = 25) where T : class
        {
            return Paginate(value, page, pageSize);
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            if (value != null && value.GetType().IsGenericType &&
        value.GetType().GetGenericTypeDefinition() == typeof(OKResultSearch<>) &&
        value.GetType().GetGenericArguments().FirstOrDefault()?.IsAssignableTo(typeof(IEnumerable)) == true)
            {
                return base.Ok(value);
            }

            return base.Ok(value.ResultadoOperation());
        }

        public override CreatedResult Created(string uri, [ActionResultObjectValue] object? value)
        {
            return base.Created(uri, new ResponseViewModel(value));
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error)
        {
            return base.BadRequest(new ResponseViewModel(false, null, JsonSerializer.Serialize(error)));
        }

        
    }

}
