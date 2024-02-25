using CRM.Application.Interfaces;
using CRM.Application.Services;
using CRM.Application.ViewModels;
using CRM.Application.ViewModels.Municipio;
using CRM.Application.ViewModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
    public class MunicipioController : BaseController
    {
        private readonly IMunicipioService municipioService;

        public MunicipioController(IMunicipioService municipioService)
        {
            this.municipioService = municipioService;
        }
        /// <summary>
        /// Obtém a lista de municípios cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// Obtém a lista de municípios cadastrados no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Lista de municípios cadastrados no sistema</returns>/// <summary>
        /// Obtém a lista de municípios cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// Obtém a lista de municípios cadastrados no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Lista de municípios cadastrados no sistema</returns>
        [HttpGet,AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<IEnumerable<MunicipioViewModel>>), 200)]
        public IActionResult Get(int? page = 1, int? pageSize = 25)
        {
            var result = municipioService.GetAll();
            return Ok(result, page, pageSize);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(municipioService.GetById(id.ToString()));
        }
        [HttpPost]
        public IActionResult Post(MunicipioViewModel municipioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.municipioService.Post(municipioViewModel));
        }
        [HttpPut]

        public IActionResult Put(MunicipioViewModel municipioViewModel)
        {
            return Ok(this.municipioService.Put(municipioViewModel));
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(string id)
        {
            return Ok(this.municipioService.Delete(id));
        }
    }
}
