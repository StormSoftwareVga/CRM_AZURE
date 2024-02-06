using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Pessoa;
using CRM.Application.ViewModels.Response;
using CRM.Domain;
using CRM.Domain.Core.Notifications;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.pessoaService.GetAll());
        }

        [HttpGet("{id}"),AllowAnonymous]
        public IActionResult GetById(string id)
        {
            return Ok(this.pessoaService.GetById(id));
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
