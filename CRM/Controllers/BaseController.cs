﻿using CRM.Application.ViewModels.Response;
using CRM.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json; 

namespace CRM
{
    public abstract class BaseController : ControllerBase
    {
        public BaseController() 
        {
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            return base.Ok(new ResponseViewModel(value));
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
