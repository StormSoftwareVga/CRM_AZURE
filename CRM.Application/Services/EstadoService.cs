using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Estado;
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
            if (!Guid.TryParse(id, out Guid ID))
                throw new Exception("ID do Estado é inválido!");

            Estado _estado = this.estadoRepository.Find(x => x.Id == ID && !x.IsDeleted);

            if (null == _estado)
                throw new Exception("Estado não encontrado");

            return this.estadoRepository.Delete(_estado);
        }

        public IEnumerable<EstadoViewModel> GetAll()
        {
            IEnumerable<Estado> _estado = this.estadoRepository.Query(x => !x.IsDeleted);

            var _estadoViewModel = mapper.Map<List<EstadoViewModel>>(_estado);

            return _estadoViewModel;
        }

        public EstadoViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioID))
                throw new Exception("ID do Estado é inválido!");

            Estado _estado = this.estadoRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

            if (null == _estado)
                throw new Exception("Estado não encontrado");

            return mapper.Map<EstadoViewModel>(_estado);
        }

        public bool Post(EstadoViewModel viewModel)
        {
            Validator.ValidateObject(estadoRepository, new ValidationContext(viewModel), true);

            var _estado = mapper.Map<Estado>(viewModel);

            var EstadoJaExiste = this.estadoRepository.Find(x => x.Nome.ToLower() == viewModel.Nome.ToLower());
            if (EstadoJaExiste == null)
            {
                this.estadoRepository.Create(_estado);

                return true;
            }

            return false;
        }

        public bool Put(EstadoViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty)
                throw new Exception("ID do Estado é inválido!");

            Estado _estado = this.estadoRepository.Find(x => x.Id == viewModel.Id && !x.IsDeleted);

            if (null == _estado)
                throw new Exception("Estado não encontrado");

            _estado = mapper.Map<Estado>(viewModel);

            _estado.DataAlteracao = DateTime.Now;

            this.estadoRepository.Update(_estado);

            return true;
        }
    }
}
