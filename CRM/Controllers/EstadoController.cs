using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Response;
using CRM.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
    public class EstadoController : BaseController
    {
        private readonly IEstadoService estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            this.estadoService = estadoService;
        }
        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(estadoService.GetAll());
        }

        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult GetById(Guid id)
        {
            return Ok(estadoService.GetById(id.ToString()));
        }
    }
}
