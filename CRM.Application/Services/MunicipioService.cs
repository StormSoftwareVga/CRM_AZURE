using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels;
using CRM.Application.ViewModels.Municipio;
using CRM.Application.ViewModels.Pessoa;
using CRM.Domain;
using CRM.Domain.Core;
using CRM.Domain.Core.CrmException;
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

        public IEnumerable<MunicipioViewModel> GetAll()
        {
            try
            {
                Log.Information("GetAll");
                IEnumerable<Municipio> _municipio = municipioRepository.GetAll();

                var _municipioViewModel = mapper.Map<List<MunicipioViewModel>>(_municipio);

                return _municipioViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;

            }
           
        }

        public MunicipioViewModel GetById(string id)
        {
            try
            {
                Log.Information("GetById");
                if (!Guid.TryParse(id, out Guid municipioID))
                    throw new PortalHttpException("ID do Municipio é inválido!");

                Municipio _municipio = municipioRepository.GetById(municipioID);

                var _municipioViewModel = mapper.Map<MunicipioViewModel>(_municipio);
                //Pessoa _pessoa = this.pessoaRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

                if (null == _municipio)
                    throw new PortalHttpException("Municipio não encontrado");

                return _municipioViewModel;
                //return mapper.Map<PessoaViewModel>(_pessoa);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }

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
