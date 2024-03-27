using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels;
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
            try
            {
                Log.Information("Delete");

                if (!Guid.TryParse(id, out Guid ID))
                    throw new Exception("ID da Região é inválido!");

                Regiao _regiao = regiaoRepository.GetById(ID);

                if (null == _regiao)
                    throw new Exception("Região não encontrado");

                return regiaoRepository.Delete(_regiao);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<RegiaoViewModel> GetAll()
        {
            try
            {
                Log.Information("GetAll");
                IEnumerable<Regiao> _regiao = regiaoRepository.GetAll();

                var _regiaoViewModel = mapper.Map<List<RegiaoViewModel>>(_regiao);

                return _regiaoViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;

            }


        }

        public RegiaoViewModel GetById(string id)
        {
            try
            {
                Log.Information("GetById");
                if (!Guid.TryParse(id, out Guid regiaoID))
                    throw new PortalHttpException("ID do Região é inválido!");

                Regiao _regiao = regiaoRepository.GetById(regiaoID);

                var _regiaoViewModel = mapper.Map<RegiaoViewModel>(_regiao);
              
                if (null == _regiao)
                    throw new PortalHttpException("Região não encontrado");

                return _regiaoViewModel;
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }

        }

        public bool Post(RegiaoViewModel viewModel)
        {
            try
            {
                Log.Information("Post");
                Validator.ValidateObject(viewModel, new ValidationContext(viewModel), true);

                var _regiao = mapper.Map<Regiao>(viewModel);


                var regiaoJaExiste = regiaoRepository.GetByName(viewModel.Nome);
                if (regiaoJaExiste == null)
                {
                    regiaoRepository.Create(_regiao);

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
