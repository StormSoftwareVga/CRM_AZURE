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
            var result = pessoaService.GetAll(page,pageSize);
            return Ok(result, page, pageSize);
        }
        /// <summary>
        /// Obtém uma pessoa com base no ID passado no sistema
        /// </summary>
        /// <remarks>
        /// Obtém uma pessoa com base no ID passado no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Obtém uma pessoa com base no ID passado no sistema</returns>
        [HttpGet("{id}"),AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<PessoaViewModel>), 200)]
        public IActionResult GetById(string id)
        {
            var result = pessoaService.GetById(id);

            return Ok(result);
            //return Ok(this.pessoaService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(CreatePessoaViewModel pessoaViewModel)
        { 
            return Ok(this.pessoaService.Post(pessoaViewModel));
        }

        [HttpPut]
        public IActionResult Put(PessoaViewModel pessoaViewModel)
        {
            return Ok(this.pessoaService.Put(pessoaViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.pessoaService.Delete(id));
        }
    }

}
