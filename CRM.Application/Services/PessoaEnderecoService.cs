using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels.PessoaEndereco;
using CRM.Domain;
using CRM.Domain.Core;
using CRM.Domain.Core.CrmException;
using CRM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Services
{
    public class PessoaEnderecoService : IPessoaEnderecoService
    {
        private readonly IMapper mapper;
        private readonly IPessoaEnderecoRepository pessoaEnderecoRepository;

        public PessoaEnderecoService(IMapper mapper, IPessoaEnderecoRepository pessoaEnderecoRepository)
        {
            this.mapper = mapper;
            this.pessoaEnderecoRepository = pessoaEnderecoRepository;
        }

        public bool Delete(string id)
        {
            try
            {
                Log.Information("Delete");
                if (!Guid.TryParse(id, out Guid ID))
                    throw new Exception("ID do PessoaEndereco é inválido!");

                PessoaEndereco _pessoaEndereco = pessoaEnderecoRepository.GetById(ID);

                if (null == _pessoaEndereco)
                    throw new Exception("PessoaEndereco não encontrado");

                return pessoaEnderecoRepository.Delete(_pessoaEndereco);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }
        



        public IEnumerable<PessoaEnderecoViewModel> GetAll()
        {
            try
            {
                Log.Information("GetAll");
                IEnumerable<PessoaEndereco> _pessoaEndereco = pessoaEnderecoRepository.GetAll();

                var _pessoaEnderecoViewModel = mapper.Map<IEnumerable<PessoaEnderecoViewModel>>(_pessoaEndereco);

                return _pessoaEnderecoViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;

            }
        }



        public PessoaEnderecoViewModel GetById(string id)
        {
            try
            {
                Log.Information("GetById");
                if (!Guid.TryParse(id, out Guid usuarioID))
                    throw new PortalHttpException("ID do PessoaEndereco é inválido!");

                PessoaEndereco _pessoaEndereco = pessoaEnderecoRepository.GetById(usuarioID);

                var _pessoaEnderecoViewModel = mapper.Map<PessoaEnderecoViewModel>(_pessoaEndereco);

                if (null == _pessoaEndereco)
                    throw new PortalHttpException("PessoaEndereço não encontrado");

                return _pessoaEnderecoViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public bool Post(PessoaEnderecoViewModel viewModel)
        {
            try
            {
                Log.Information("Post");
                Validator.ValidateObject(pessoaEnderecoRepository, new ValidationContext(viewModel), true);

                var _pessoaEndereco = mapper.Map<PessoaEndereco>(viewModel);

                var PessoaEnderecoJaExiste = pessoaEnderecoRepository.GetByEndereco(viewModel.CEP, viewModel.Logradouro, viewModel.Numero);
                if (PessoaEnderecoJaExiste == null)
                {
                    pessoaEnderecoRepository.Create(_pessoaEndereco);

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

        public bool Put(PessoaEnderecoViewModel viewModel)
        {
            try
            {
                Log.Information("Put");
                if (viewModel.Id == Guid.Empty)
                    throw new Exception("ID do PessoaEndereco é inválido!");

                PessoaEndereco _pessoaEndereco = pessoaEnderecoRepository.GetById(viewModel.Id);

                if (null == _pessoaEndereco)
                    throw new Exception("PessoaEndereco não encontrado");

                _pessoaEndereco = mapper.Map<PessoaEndereco>(viewModel);

                _pessoaEndereco.DataAlteracao = DateTime.Now;

                pessoaEnderecoRepository.Update(_pessoaEndereco);

                return true;
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }
    }
}
