using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRM.Auth.Services;
using CRM.Domain;
using CRM.Application.ViewModels.User;
using BCrypt.Net;
using CRM.Domain.Core.CrmException;

namespace CRM.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public List<GetUsuarioViewModel> Get()
        {
            IEnumerable<Usuario> _variacoes = this.usuarioRepository.GetAll();

            var _usuarioViewModel = mapper.Map<List<GetUsuarioViewModel>>(_variacoes);

            return _usuarioViewModel;
        }

        public GetUsuarioViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("ID do usuário é inválido!");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            return mapper.Map<GetUsuarioViewModel>(_usuario);
        }

        public bool Post(CreateUsuarioViewModel usuarioViewModel)
        { 
            Validator.ValidateObject(usuarioViewModel, new ValidationContext(usuarioViewModel), true);

            var _usuario = mapper.Map<Usuario>(usuarioViewModel);

            var usuarioJaExiste = this.usuarioRepository.Find(x => x.Email.ToLower() == usuarioViewModel.Email.ToLower());
            if(usuarioJaExiste == null)
            {
                this.usuarioRepository.Create(_usuario);

                return true;
            }

            return false;

        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id == Guid.Empty)
                throw new Exception("ID do usuário é inválido!");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioViewModel.Id && !x.IsDeleted);
            
            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            _usuario.Nome = usuarioViewModel.Nome;
            _usuario.Email = usuarioViewModel.Email;

            _usuario.DataAlteracao = DateTime.Now;

            this.usuarioRepository.Update(_usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("ID do usuário é inválido!");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _usuario)
                throw new Exception("Usuário não encontrado");

            return this.usuarioRepository.Delete(_usuario);

        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
                throw new Exception("Os campos E-mail e Senha são obrigatórios!");

            Usuario _usuario = this.usuarioRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == usuario.Email.ToLower());

            if (null == _usuario)
                throw new Exception("Usuário ou senha Invalido");

            
            if ( _usuario.SenhaValida(usuario.Senha) == false)
                throw new Exception("Usuário ou senha Invalido");


            return new UserAuthenticateResponseViewModel(mapper.Map<UsuarioViewModel>(_usuario), TokenService.GenerateToken(_usuario));
        }
    }
}
