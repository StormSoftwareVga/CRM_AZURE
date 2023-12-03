using CRM.Application.Interfaces;
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
    }
}
