using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Pessoa;
using CRM.Application.ViewModels.User;
using CRM.Domain;
using CRM.Domain.Core;
using CRM.Domain.Core.CrmException;
using CRM.Domain.Interfaces;
using Storm.Tecnologia.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IMapper mapper;
        private readonly IControladorPessoaService controladorPessoaService;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper, IControladorPessoaService controladorPessoaService)
        {
            this.pessoaRepository = pessoaRepository;
            this.mapper = mapper;
            this.controladorPessoaService = controladorPessoaService;
        }

        public IEnumerable<PessoaViewModel> GetAll()
        {
            try
            {
                Log.Information("GetAll");
                IEnumerable<Pessoa> _pessoa = pessoaRepository.GetAll();

                var _pessoaViewModel = mapper.Map<List<PessoaViewModel>>(_pessoa);

                return _pessoaViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public PessoaViewModel GetById(string id)
        {
            try
            {
                Log.Information("GetById");
                if (!Guid.TryParse(id, out Guid usuarioID))
                    throw new PortalHttpException("ID da Pessoa é inválido!");

                Pessoa _pessoa = pessoaRepository.GetById(usuarioID);

                var _pessoaViewModel = mapper.Map<PessoaViewModel>(_pessoa);
              

                if (null == _pessoa)
                    throw new PortalHttpException("Pessoa não encontrada");

                return _pessoaViewModel;
              
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
            
        }

        public bool Post(PessoaViewModel viewModel)
        {
            CreatePessoaViewModel vm = new CreatePessoaViewModel()
            {
                Documento = viewModel.Documento,
                Email = viewModel.Email,
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Tipo = viewModel.Tipo,
                DocumentoTipo = viewModel.DocumentoTipo
            };

            return Post(vm);
        }

        public bool Post(CreatePessoaViewModel viewModel)
        {
            try
            {
                Log.Information("Post");
                Validator.ValidateObject(viewModel, new ValidationContext(viewModel), true);

                var _pessoa = mapper.Map<Pessoa>(viewModel);

                var pessoaJaExiste = pessoaRepository.GetByDocument(viewModel.Documento);
                if (pessoaJaExiste == null)
                {
                    pessoaRepository.Create(_pessoa);

                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public bool Put(PessoaViewModel viewModel)
        {
            try
            {
                Log.Information("Put");
                if (viewModel.Id == Guid.Empty)
                    throw new Exception("ID da pessoa é inválido!");

                Pessoa _pessoa = pessoaRepository.GetById(viewModel.Id);

                if (null == _pessoa)
                    throw new Exception("Pessoa não encontrada");

                _pessoa = mapper.Map<Pessoa>(viewModel);

                _pessoa.DataAlteracao = DateTime.Now;

                pessoaRepository.Update(_pessoa);

                return true;
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                Log.Information("Delete");
                if (!Guid.TryParse(id, out Guid ID))
                    throw new Exception("ID da pessoa é inválido!");

                Pessoa _pessoa = pessoaRepository.GetById(ID);

                if (null == _pessoa)
                    throw new Exception("Pessoa não encontrada");

                return pessoaRepository.Delete(_pessoa);
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }
    }
}
