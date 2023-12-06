using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Pessoa;
using CRM.Domain;
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

        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(this.pessoaService.GetAll());
        }

        [HttpGet("{id}"),AllowAnonymous]
        public IActionResult GetById(string id)
        {
            return Ok(this.pessoaService.GetById(id));
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(CreatePessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.pessoaService.Post(pessoaViewModel));
        }

        [HttpPut, AllowAnonymous]
        public IActionResult Put(PessoaViewModel pessoaViewModel)
        {
            return Ok(this.pessoaService.Put(pessoaViewModel));
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public IActionResult Delete(string id)
        {
            return Ok(this.pessoaService.Delete(id));
        }
    }

}
