using System.Collections.Generic;
using CRM.Application.ViewModels.User;
using CRM.Domain;

namespace CRM.Application
{
    public interface IUsuarioService: IBaseService<Usuario, UsuarioViewModel>
    {
        new IEnumerable<GetUsuarioViewModel> GetAll();
        GetUsuarioViewModel GetById(string id);
        bool Post(CreateUsuarioViewModel usuarioViewModel);
        bool Put(UsuarioViewModel usuarioViewModel);
        bool Delete(string id);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);
    }
}
