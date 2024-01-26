﻿using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Response;
using CRM.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
    public class PaisController : BaseController
    {
        private readonly IPaisService paisService;

        public PaisController(IPaisService paisService)
        {
            this.paisService = paisService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(paisService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(paisService.GetById(id.ToString()));
        }
    }
}
