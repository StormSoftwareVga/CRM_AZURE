﻿using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Pessoa;
using CRM.Application.ViewModels.User;
using CRM.Domain;
using CRM.Domain.Core;
using CRM.Domain.Core.CrmException;
using CRM.Domain.Interfaces;
using Storm.Tecnologia.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IMapper mapper;
        private readonly IControladorPessoaService controladorPessoaService;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper, IControladorPessoaService controladorPessoaService)
        {
            this.pessoaRepository = pessoaRepository;
            this.mapper = mapper;
            this.controladorPessoaService = controladorPessoaService;
        }

        public IEnumerable<PessoaViewModel> GetAll(int? page = 0, int? pageSize = 0)
        {
            try
            {
                Log.Information("GetAll");
                IEnumerable<Pessoa> _pessoa = pessoaRepository.GetAll(page, pageSize);

                var _pessoaViewModel = mapper.Map<List<PessoaViewModel>>(_pessoa);

                return _pessoaViewModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
        }

        public PessoaViewModel GetById(string id)
        {
            try
            {
                Log.Information("GetById");
                if (!Guid.TryParse(id, out Guid usuarioID))
                    throw new PortalHttpException("ID da Pessoa é inválido!");

                Pessoa _pessoa = this.pessoaRepository.Find(x => x.Id == usuarioID && !x.IsDeleted);

                if (null == _pessoa)
                    throw new PortalHttpException("Pessoa não encontrada");

                return mapper.Map<PessoaViewModel>(_pessoa);
            }
            catch (PortalHttpException ex)
            {
                Log.Error(ex, ex.Message);
                throw ex;
            }
            
        }

        public bool Post(CreatePessoaViewModel viewModel)
        {
           Validator.ValidateObject(viewModel, new ValidationContext(viewModel));

            if (null == this.pessoaRepository.Find(x => x.Documento.Replace(".", "").Replace("-", "").Replace("/", "") == viewModel.Documento.Replace(".", "").Replace("-", "").Replace("/", "")))
                return controladorPessoaService.CadastrarNovoLead(mapper.Map<Pessoa>(viewModel)).Result;
            
            return false;
        }

        public bool Put(PessoaViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty)
                throw new Exception("ID da pessoa é inválido!");

            Pessoa _pessoa = this.pessoaRepository.Find(x => x.Id == viewModel.Id && !x.IsDeleted);

            if (null == _pessoa)
                throw new Exception("Pessoa não encontrada");

            _pessoa = mapper.Map<Pessoa>(viewModel);

            _pessoa.DataAlteracao = DateTime.Now;

            this.pessoaRepository.Update(_pessoa);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid ID))
                throw new Exception("ID da pessoa é inválido!");

            Pessoa _pessoa = this.pessoaRepository.Find(x => x.Id == ID && !x.IsDeleted);

            if (null == _pessoa)
                throw new Exception("Pessoa não encontrada");

            return this.pessoaRepository.Delete(_pessoa);
        }
    }
}
