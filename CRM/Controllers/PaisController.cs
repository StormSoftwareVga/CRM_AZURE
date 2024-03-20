using CRM.Application;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels;
using CRM.Application.ViewModels.Pessoa;
using CRM.Application.ViewModels.Response;
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
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<IEnumerable<PaisViewModel>>), 200)]
        public IActionResult Get(int? page = 1, int? pageSize = 25)
        {
            var result = paisService.GetAll();
            return Ok(result, page, pageSize);
        }

        /// <summary>
        /// Obtém uma país com base no ID passado no sistema
        /// </summary>
        /// <remarks>
        /// Obtém uma país com base no ID passado no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Obtém uma país com base no ID passado no sistema</returns>
        [HttpGet("{id}"), AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<PaisViewModel>), 200)]
        public IActionResult GetById(string id)
        {
            var result = paisService.GetById(id);

            return Ok(result);
        }

        [HttpPost]

        public IActionResult Post(PaisViewModel paisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.paisService.Post(paisViewModel));
        }
        [HttpPut]

        public IActionResult Put(PaisViewModel paisViewModel)
        {
            return Ok(this.paisService.Put(paisViewModel));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(string id)
        {
            return Ok(this.paisService.Delete(id));
        }


    }
}
