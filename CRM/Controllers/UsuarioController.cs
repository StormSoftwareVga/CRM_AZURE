using CRM;
using CRM.Application;
using CRM.Application.ViewModels.Response;
using CRM.Application.ViewModels.User;
using CRM.Auth.Services;
using CRM.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiSpa.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.usuarioService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.usuarioService.GetById(id));
        }

        //Descomente o AllowAnonymous Para criar o primeiro usuario e testar
        [HttpPost, AllowAnonymous]
        public IActionResult Post(CreateUsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Post(usuarioViewModel));
        }

        [HttpPost("autenticate"), AllowAnonymous]
        public IActionResult Autenticar(UserAuthenticateRequestViewModel usuarioViewModel)
        {
            try { 
                return Ok(this.usuarioService.Authenticate(usuarioViewModel));
            }catch(Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        public IActionResult Put(UsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Put(usuarioViewModel));
        }

        [HttpDelete]
        public IActionResult Delete()
        { 
            var _idUsuario = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

            return Ok(this.usuarioService.Delete(_idUsuario));

        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(string userId)
        {
            return Ok(this.usuarioService.Delete(userId));
        }
    }
}
