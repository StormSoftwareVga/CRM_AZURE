using System.Collections.Generic;
using CRM.Application.ViewModels.User;

namespace CRM.Application
{
    public interface IUsuarioService
    {
        List<GetUsuarioViewModel> Get();
        GetUsuarioViewModel GetById(string id);
        bool Post(CreateUsuarioViewModel usuarioViewModel);
        bool Put(UsuarioViewModel usuarioViewModel);
        bool Delete(string id);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);
    }
}
