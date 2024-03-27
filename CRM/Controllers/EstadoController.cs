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
        /// Obtém a lista de estados cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// Obtém a lista de estados cadastrados no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Lista de estados cadastrados no sistema</returns>
        [HttpGet, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<IEnumerable<EstadoViewModel>>), 200)]
        public IActionResult Get(int? page = 1, int? pageSize = 25)
        {
            var result = estadoService.GetAll();
            return Ok(result, page, pageSize);
        }

        /// <summary>
        /// Obtém um estado com base no ID passado no sistema
        /// </summary>
        /// <remarks>
        /// Obtém um estado com base no ID passado no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Obtém um estado com base no ID passado no sistema</returns>
        [HttpGet("{id}"), AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<EstadoViewModel>), 200)]
        public IActionResult GetById(string id)
        {
            var result = estadoService.GetById(id);

            return Ok(result);
        }

        /// <summary>
        /// Insere um estado com base nos dados passados no json
        /// </summary>
        /// <remarks>
        /// Insere um estado com base nos dados passados no json
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Insere um estados com base nos dados passado no json</returns>]
        [HttpPost, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<EstadoViewModel>), 200)]
        public IActionResult Post(EstadoViewModel estadoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = estadoService.Post(estadoViewModel);
            return Ok(result);
        }
        /// <summary>
        /// Edita um estado com base no ID
        /// </summary>
        /// <remarks>
        /// Edita um estado com base no ID
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Edita um estado com base no ID</returns>]
        [HttpPut, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<EstadoViewModel>), 200)]
        public IActionResult Put(EstadoViewModel estadoViewModel)
        {
            var result = estadoService.Put(estadoViewModel);
            return Ok(result);
        }

        /// <summary>
        /// Deleta um estado com base no ID
        /// </summary>
        /// <remarks>
        /// Deleta um estado com base no ID
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Deleta um estado com base ID</returns>]
        [HttpDelete("{id}"), AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<EstadoViewModel>), 200)]
        public IActionResult Delete(string id)
        {
            var result = estadoService.Delete(id);
            return Ok(result);
        }
    }
}
