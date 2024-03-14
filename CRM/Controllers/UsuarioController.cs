using CRM;
using CRM.Application;
using CRM.Application.Interfaces;
using CRM.Application.Services;
using CRM.Application.ViewModels;
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
        /// <summary>
        /// Obtém a lista de usuários cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// Obtém a lista de usuários cadastrados no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Lista de usuários cadastrados no sistema</returns>
        [HttpGet, AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<IEnumerable<GetUsuarioViewModel>>), 200)]
        public IActionResult GetAll(int? page = 1, int? pageSize = 25)
        {
            var result = usuarioService.GetAll();

            return Ok(result, page, pageSize);
        }

        /// <summary>
        /// Obtém um usuário com base no ID passado no sistema
        /// </summary>
        /// <remarks>
        /// Obtém um usuário com base no ID passado no sistema
        /// </remarks>
        /// <include file='Response.xml' path="ResponseGroup[@name='resp']/*"/>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Obtém um usuário com base no ID passado no sistema</returns>
        [HttpGet("{id}"), AllowAnonymous]
        [Produces("application/json"), ProducesResponseType(typeof(OKResultSearch<GetUsuarioViewModel>), 200)]
        public IActionResult GetById(string id)
        {
            var result = usuarioService.GetById(id);

            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(string id)
        //{
        //    return Ok(this.usuarioService.GetById(id));
        //}
         
        [HttpPost]
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
