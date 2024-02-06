using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Response;
using CRM.Domain.Core.Notifications;
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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(municipioService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(municipioService.GetById(id.ToString()));
        }
    }
}
