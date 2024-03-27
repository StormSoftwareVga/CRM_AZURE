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
            try
            {
                Log.Information("Delete");

                if (!Guid.TryParse(id, out Guid ID))
                    throw new Exception("ID do País é inválido!");

                Pais _pais = paisRepository.GetById(ID);

                if (null == _pais)
                    throw new Exception("País não encontrado");

                return paisRepository.Delete(_pais);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<PaisViewModel> GetAll()
        {
            try
            {
                Log.Information("GetAll");
                IEnumerable<Pais> _pais = paisRepository.GetAll();

                var _paisViewModel = mapper.Map<List<PaisViewModel>>(_pais);

                return _paisViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            
            }

          
        }

        public PaisViewModel GetById(string id)
        {
            try
            {
                Log.Information("GetById");
                if (!Guid.TryParse(id, out Guid paisID))
                    throw new PortalHttpException("ID do País é inválido!");

                Pais _pais = paisRepository.GetById(paisID);

                var _paisViewModel = mapper.Map<PaisViewModel>(_pais);
          

                if (null == _pais)
                    throw new PortalHttpException("País não encontrado");

                return _paisViewModel;
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }

        }

        public bool Post(PaisViewModel viewModel)
        {
            try
            {
                Log.Information("Post");
                Validator.ValidateObject(viewModel, new ValidationContext(viewModel), true);

                var _pais = mapper.Map<Pais>(viewModel);


                var paisJaExiste = paisRepository.GetByName(viewModel.Nome);
                if (paisJaExiste == null)
                {
                    paisRepository.Create(_pais);

                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public bool Put(PaisViewModel viewModel)
        {
            try
            {
                Log.Information("Put");
                if (viewModel.Id == Guid.Empty)
                    throw new Exception("ID do País é inválido!");

                Pais _pais = paisRepository.GetById(viewModel.Id);

                if (_pais == null)
                    throw new Exception("País não encontrado");

                _pais = mapper.Map<Pais>(viewModel);

                _pais.DataAlteracao = DateTime.Now;

                paisRepository.Update(_pais);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }
    }
}
