using AutoMapper;
using CRM.Domain;

namespace CRM.Application
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel -> Domain

            CreateMap<UsuarioViewModel, Usuario>();

            #endregion

            #region Domain -> ViewModel

            CreateMap<Usuario, UsuarioViewModel>();

            #endregion
        }
    }
}
