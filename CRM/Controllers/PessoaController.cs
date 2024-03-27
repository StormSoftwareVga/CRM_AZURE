using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Pessoa;
using CRM.Application.ViewModels.Response;
using CRM.Domain;
using CRM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
    public class PessoaController : BaseController
    {
        private readonly IPessoaService pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        /// <summary>
        /// Obtém a lista de pessoas cadastradas no sistema
        /// </summary>
        /// <remarks>
        /// Obtém a lista de pessoas cadastradas no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Lista de pessoas cadastradas no sistema</returns>
        [HttpGet, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<IEnumerable<PessoaViewModel>>), 200)]
        public IActionResult Get(int? page = 1, int? pageSize = 25)
        {
            var result = pessoaService.GetAll();
            return Ok(result, page, pageSize);
        }
        /// <summary>
        /// Obtém uma pessoa com base no ID passado no sistema
        /// </summary>
        /// <remarks>
        /// Obtém uma pessoa com base no ID passado no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Obtém uma pessoa com base no ID passado no sistema</returns>
        [HttpGet("{id}"),AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<PessoaViewModel>), 200)]
        public IActionResult GetById(string id)
        {
            var result = pessoaService.GetById(id);

            return Ok(result);
        }

        /// <summary>
        /// Insere uma pessoa com base nos dados passados no json
        /// </summary>
        /// <remarks>
        /// Insere uma pessoa com base nos dados passados no json
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Insere uma pessoa com base nos dados passados no json</returns>
        [HttpPost, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<PessoaViewModel>), 200)]
        public IActionResult Post(CreatePessoaViewModel pessoaViewModel)
        { 
            var result = pessoaService.Post(pessoaViewModel);
            return Ok(result);
        }

        /// <summary>
        /// Edita uma pessoa com base nos dados passados no json
        /// </summary>
        /// <remarks>
        /// Edita uma pessoa com base nos dados passados no json
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Edita uma pessoa com base nos dados passados no json</returns>
        [HttpPut, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<PessoaViewModel>), 200)]
        public IActionResult Put(PessoaViewModel pessoaViewModel)
        {
            var result = pessoaService.Put(pessoaViewModel);
            return Ok(result);
        }

        /// <summary>
        /// Deleta uma pessoa com base nos dados passados no json
        /// </summary>
        /// <remarks>
        /// Deleta uma pessoa com base nos dados passados no json
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <returns>Deleta uma pessoa com base nos dados passados no json</returns>
        [HttpDelete("{id}"), AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<PessoaViewModel>), 200)]
        public IActionResult Delete(string id)
        {
            var result = pessoaService.Delete(id);
            return Ok(result);
        }
    }

}
