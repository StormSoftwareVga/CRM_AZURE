using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Estado;
using CRM.Application.ViewModels.Response;
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
        /// <summary>
        /// Obtém a lista de país cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// Obtém a lista de país cadastrados no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Lista de país cadastrados no sistema</returns>
        [HttpGet, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<IEnumerable<EstadoViewModel>>), 200)]
        public IActionResult Get (int? page = 1, int? pageSize = 25)
        {
            var result = estadoService.GetAll(page, pageSize);
            return Ok(result, page, pageSize);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(estadoService.GetById(id.ToString()));
        }
        [HttpPost]

        public IActionResult Post(EstadoViewModel estadoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.estadoService.Post(estadoViewModel));
        }
        [HttpPut]
        public IActionResult Put(EstadoViewModel estadoViewModel)
        {
            return Ok(this.estadoService.Put(estadoViewModel));
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(string id)
        {
            return Ok(this.estadoService.Delete(id));
        }
    }
}
