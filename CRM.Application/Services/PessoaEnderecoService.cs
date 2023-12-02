using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels.PessoaEndereco;
using CRM.Domain;
using CRM.Domain.Interfaces;
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
            if (!Guid.TryParse(id, out Guid ID))
                throw new Exception("ID do PessoaEndereco é inválido!");

            PessoaEndereco _pessoaEndereco = this.pessoaEnderecoRepository.Find(x => x.Id == ID && !x.IsDeleted);

            if (null == _pessoaEndereco)
                throw new Exception("PessoaEndereco não encontrado");

            return this.pessoaEnderecoRepository.Delete(_pessoaEndereco);
        }

        public IEnumerable<PessoaEnderecoViewModel> GetAll()
        {
            IEnumerable<PessoaEndereco> _pessoaEndereco = this.pessoaEnderecoRepository.Query(x => !x.IsDeleted);

            var _pessoaEnderecoViewModel = mapper.Map<List<PessoaEnderecoViewModel>>(_pessoaEndereco);

            return _pessoaEnderecoViewModel;
        }

        public PessoaEnderecoViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("ID do PessoaEndereco é inválido!");

            PessoaEndereco _pessoaEndereco = this.pessoaEnderecoRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _pessoaEndereco)
                throw new Exception("PessoaEndereco não encontrado");

            return mapper.Map<PessoaEnderecoViewModel>(_pessoaEndereco);
        }

        public bool Post(PessoaEnderecoViewModel viewModel)
        {
            Validator.ValidateObject(pessoaEnderecoRepository, new ValidationContext(viewModel), true);

            var _pessoaEndereco = mapper.Map<PessoaEndereco>(viewModel);

            var PessoaEnderecoJaExiste = this.pessoaEnderecoRepository.Find(x => x.CEP == viewModel.CEP && x.Logradouro == viewModel.Logradouro && x.Numero == viewModel.Numero);
            if (PessoaEnderecoJaExiste == null)
            {
                this.pessoaEnderecoRepository.Create(_pessoaEndereco);

                return true;
            }

            return false;
        }

        public bool Put(PessoaEnderecoViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty)
                throw new Exception("ID do PessoaEndereco é inválido!");

            PessoaEndereco _pessoaEndereco = this.pessoaEnderecoRepository.Find(x => x.Id == viewModel.Id && !x.IsDeleted);

            if (null == _pessoaEndereco)
                throw new Exception("PessoaEndereco não encontrado");

            _pessoaEndereco = mapper.Map<PessoaEndereco>(viewModel);

            _pessoaEndereco.DataAlteracao = DateTime.Now;

            this.pessoaEnderecoRepository.Update(_pessoaEndereco);

            return true;
        }
    }
}
