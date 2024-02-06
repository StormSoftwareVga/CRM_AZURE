using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Estado;
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
        [HttpPost, AllowAnonymous]

        public IActionResult Post(EstadoViewModel estadoViewModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.estadoService.Post(estadoViewModel));
        }
        [HttpPut, AllowAnonymous]
        public IActionResult Put(EstadoViewModel estadoViewModel)
        {
            return Ok(this.estadoService.Put(estadoViewModel));
        }
        [HttpDelete("{id}"), AllowAnonymous]

        public IActionResult Delete(string id) 
        {
            return Ok(this.estadoService.Delete(id));
        }
    }
}
