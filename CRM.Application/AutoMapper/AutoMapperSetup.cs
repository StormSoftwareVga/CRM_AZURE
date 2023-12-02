using AutoMapper;
using CRM.Application.ViewModels;
using CRM.Application.ViewModels.Estado;
using CRM.Application.ViewModels.Municipio;
using CRM.Application.ViewModels.Pessoa;
using CRM.Application.ViewModels.PessoaEndereco;
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

            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<CreatePessoaViewModel, Pessoa>();

            CreateMap<PaisViewModel, Pais>();
            CreateMap<RegiaoViewModel, Regiao>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<MunicipioViewModel, Municipio>();
            CreateMap<PessoaEnderecoViewModel, PessoaEndereco>();

            #endregion

            #region Domain -> ViewModel

            CreateMap<Usuario, GetUsuarioViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();

            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<Pessoa, CreatePessoaViewModel>();

            CreateMap<Pais, PaisViewModel>();
            CreateMap<Regiao, RegiaoViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Municipio, MunicipioViewModel>();
            CreateMap<PessoaEndereco, PessoaEnderecoViewModel>();

            #endregion
        }
    }
}
