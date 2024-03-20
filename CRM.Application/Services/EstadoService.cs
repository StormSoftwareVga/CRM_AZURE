using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels;
using CRM.Application.ViewModels.Estado;
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
    public class EstadoService : IEstadoService
    {
        private readonly IMapper mapper;
        private readonly IEstadoRepository estadoRepository;

        public EstadoService(IMapper mapper, IEstadoRepository estadoRepository)
        {
            this.mapper = mapper;
            this.estadoRepository = estadoRepository;
        }

        public bool Delete(string id)
        {
            try
            {
                Log.Information("Delete");

                if (!Guid.TryParse(id, out Guid ID))
                    throw new Exception("ID do Estado é inválido!");

                Estado _estado = estadoRepository.GetById(ID);

                if (null == _estado)
                    throw new Exception("Estado não encontrado");

                return estadoRepository.Delete(_estado);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
            
        }

        public IEnumerable<EstadoViewModel> GetAll()
        {
            try
            {
                Log.Information("GetAll");
                IEnumerable<Estado> _estado = estadoRepository.GetAll();

                var _estadoViewModel = mapper.Map<List<EstadoViewModel>>(_estado);

                return _estadoViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;

            }

        }

        public EstadoViewModel GetById(string id)
        {
            try
            {
                Log.Information("GetById");
                if (!Guid.TryParse(id, out Guid estadoID))
                    throw new PortalHttpException("ID do Estado é inválido!");

                Estado _estado = estadoRepository.GetById(estadoID);

                var _estadoViewModel = mapper.Map<EstadoViewModel>(_estado);
                

                if (null == _estado)
                    throw new PortalHttpException("Estado não encontrado");

                return _estadoViewModel;
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }

        }

        public bool Post(EstadoViewModel viewModel)
        {
            try
            {
                Log.Information("Post");
                Validator.ValidateObject(viewModel, new ValidationContext(viewModel), true);

                var _estado = mapper.Map<Estado>(viewModel);


                var estadoJaExiste = estadoRepository.GetByName(viewModel.Nome);
                if (estadoJaExiste == null)
                {
                    estadoRepository.Create(_estado);

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

        public bool Put(EstadoViewModel viewModel)
        {
            try
            {
                Log.Information("Put");
                if (viewModel.Id == Guid.Empty)
                    throw new Exception("ID do Estado é inválido!");

                Estado _estado = estadoRepository.GetById(viewModel.Id);

                if (_estado == null)
                    throw new Exception("Estado não encontrado");

                _estado = mapper.Map<Estado>(viewModel);

                _estado.DataAlteracao = DateTime.Now;

                estadoRepository.Update(_estado);

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
