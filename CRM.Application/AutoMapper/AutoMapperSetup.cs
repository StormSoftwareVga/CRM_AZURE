using AutoMapper;
using CRM.Application.ViewModels.User;
using CRM.Domain;

namespace CRM.Application
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel -> Domain

            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<CreateUsuarioViewModel, Usuario>();

            #endregion

            #region Domain -> ViewModel
            
            CreateMap<Usuario, GetUsuarioViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();

            #endregion
        }
    }
}
