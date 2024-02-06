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
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository paisRepository;
        private readonly IMapper mapper;

        public PaisService(IPaisRepository paisRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.paisRepository = paisRepository;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid ID))
                throw new Exception("ID do Pais é inválido!");

            Pais _pais = this.paisRepository.Find(x => x.Id == ID && !x.IsDeleted);

            if (null == _pais)
                throw new Exception("Pais não encontrado");

            return this.paisRepository.Delete(_pais);
        }

        public IEnumerable<PaisViewModel> GetAll()
        {
            IEnumerable<Pais> _pais = this.paisRepository.Query(x => !x.IsDeleted);

            var _paisViewModel = mapper.Map<List<PaisViewModel>>(_pais);

            return _paisViewModel;
        }

        public PaisViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("ID do Pais é inválido!");

            Pais _pais = this.paisRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _pais)
                throw new Exception("Pais não encontrado");

            return mapper.Map<PaisViewModel>(_pais);
        }

        public bool Post(PaisViewModel viewModel)
        {
            Validator.ValidateObject(viewModel, new ValidationContext(viewModel), true);

            var _pais = mapper.Map<Pais>(viewModel);

            var PaisJaExiste = this.paisRepository.Find(x => x.Nome.ToLower() == viewModel.Nome.ToLower());
            if (PaisJaExiste == null)
            {
                this.paisRepository.Create(_pais);

                return true;
            }

            return false;
        }

        public bool Put(PaisViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty)
                throw new Exception("ID do Pais é inválido!");

            Pais _pais = this.paisRepository.Find(x => x.Id == viewModel.Id && !x.IsDeleted);

            if (null == _pais)
                throw new Exception("Pais não encontrado");

            _pais = mapper.Map<Pais>(viewModel);

            _pais.DataAlteracao = DateTime.Now;

            this.paisRepository.Update(_pais);

            return true;
        }
    }
}
