using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels;
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
    public class RegiaoService : IRegiaoService
    {
        private readonly IRegiaoRepository regiaoRepository;
        private readonly IMapper mapper;

        public RegiaoService(IRegiaoRepository regiaoRepository, IMapper mapper)
        {
            this.regiaoRepository = regiaoRepository;
            this.mapper = mapper;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid ID))
                throw new Exception("ID do Regiao é inválido!");

            Regiao _regiao = this.regiaoRepository.Find(x => x.Id == ID && !x.IsDeleted);

            if (null == _regiao)
                throw new Exception("Regiao não encontrado");

            return this.regiaoRepository.Delete(_regiao);
        }

        public IEnumerable<RegiaoViewModel> GetAll()
        {
            IEnumerable<Regiao> _regiao = this.regiaoRepository.Query(x => !x.IsDeleted);

            var _regiaoViewModel = mapper.Map<List<RegiaoViewModel>>(_regiao);

            return _regiaoViewModel;
        }

        public RegiaoViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("ID do Regiao é inválido!");

            Regiao _regiao = this.regiaoRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _regiao)
                throw new Exception("Regiao não encontrado");

            return mapper.Map<RegiaoViewModel>(_regiao);
        }

        public bool Post(RegiaoViewModel viewModel)
        {
            Validator.ValidateObject(regiaoRepository, new ValidationContext(viewModel), true);

            var _regiao = mapper.Map<Regiao>(viewModel);

            var RegiaoJaExiste = this.regiaoRepository.Find(x => x.Nome.ToLower() == viewModel.Nome.ToLower());
            if (RegiaoJaExiste == null)
            {
                this.regiaoRepository.Create(_regiao);

                return true;
            }

            return false;
        }

        public bool Put(RegiaoViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty)
                throw new Exception("ID do Regiao é inválido!");

            Regiao _regiao = this.regiaoRepository.Find(x => x.Id == viewModel.Id && !x.IsDeleted);

            if (null == _regiao)
                throw new Exception("Regiao não encontrado");

            _regiao = mapper.Map<Regiao>(viewModel);

            _regiao.DataAlteracao = DateTime.Now;

            this.regiaoRepository.Update(_regiao);

            return true;
        }
    }
}
