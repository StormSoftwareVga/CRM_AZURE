using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Municipio;
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
    public class MunicipioService : IMunicipioService
    {
        private readonly IMapper mapper;
        private readonly IMunicipioRepository municipioRepository;

        public MunicipioService(IMapper mapper, IMunicipioRepository municipioRepository)
        {
            this.mapper = mapper;
            this.municipioRepository = municipioRepository;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid ID))
                throw new Exception("ID do Municipio é inválido!");

            Municipio _municipio = this.municipioRepository.Find(x => x.Id == ID && !x.IsDeleted);

            if (null == _municipio)
                throw new Exception("Municipio não encontrado");

            return this.municipioRepository.Delete(_municipio);
        }

        public IEnumerable<MunicipioViewModel> GetAll(int? page = 0, int? pageSize = 0)
        {
            IEnumerable<Municipio> _municipio = this.municipioRepository.Query(x => !x.IsDeleted);

            
            var _municipioViewModel = mapper.Map<List<MunicipioViewModel>>(_municipio);

            return _municipioViewModel;
        }

        public MunicipioViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("ID do Municipio é inválido!");

            Municipio _municipio = this.municipioRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _municipio)
                throw new Exception("Municipio não encontrado");

            return mapper.Map<MunicipioViewModel>(_municipio);
        }

        public bool Post(MunicipioViewModel viewModel)
        {
            Validator.ValidateObject(viewModel, new ValidationContext(viewModel), true);

            var _municipio = mapper.Map<Municipio>(viewModel);

            var MunicipioJaExiste = this.municipioRepository.Find(x => x.Nome.ToLower() == viewModel.Nome.ToLower());
            if (MunicipioJaExiste == null)
            {
                this.municipioRepository.Create(_municipio);

                return true;
            }

            return false;
        }

        public bool Put(MunicipioViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty)
                throw new Exception("ID do Municipio é inválido!");

            Municipio _municipio = this.municipioRepository.Find(x => x.Id == viewModel.Id && !x.IsDeleted);

            if (null == _municipio)
                throw new Exception("Municipio não encontrado");

            _municipio = mapper.Map<Municipio>(viewModel);

            _municipio.DataAlteracao = DateTime.Now;

            this.municipioRepository.Update(_municipio);

            return true;
        }
    }
}
