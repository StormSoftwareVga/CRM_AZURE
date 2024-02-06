using CRM.Application.Interfaces;
using CRM.Application.ViewModels;
using CRM.Application.ViewModels.Pessoa;
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
        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(paisService.GetAll());
        }

        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult GetById(Guid id)
        {
            return Ok(paisService.GetById(id.ToString()));
        }

        [HttpPost, AllowAnonymous]

        public IActionResult Post(PaisViewModel paisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.paisService.Post(paisViewModel));
        }
        [HttpPut, AllowAnonymous]

        public IActionResult Put(PaisViewModel paisViewModel)
        {
            return Ok(this.paisService.Put(paisViewModel));
        }

        [HttpDelete("{id}"), AllowAnonymous]

        public IActionResult Delete(string id) 
        {
            return Ok(this.paisService.Delete(id));
        }


    }
}
