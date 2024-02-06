using CRM.Application.Interfaces;
using CRM.Application.ViewModels;
using CRM.Application.ViewModels.Municipio;
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
        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(municipioService.GetAll());
        }

        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult GetById(Guid id)
        {
            return Ok(municipioService.GetById(id.ToString()));
        }
        [HttpPost, AllowAnonymous]
        public IActionResult Post(MunicipioViewModel municipioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.municipioService.Post(municipioViewModel));
        }
        [HttpPut, AllowAnonymous]

        public IActionResult Put(MunicipioViewModel municipioViewModel)
        {
            return Ok(this.municipioService.Put(municipioViewModel));
        }
        [HttpDelete("{id}"), AllowAnonymous]

        public IActionResult Delete(string id)
        {
            return Ok(this.municipioService.Delete(id));
        }
    }
}
