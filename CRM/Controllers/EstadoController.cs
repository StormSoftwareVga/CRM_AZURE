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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(estadoService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(estadoService.GetById(id.ToString()));
        }
    }
}
