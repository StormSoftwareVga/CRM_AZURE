using AutoMapper;
using CRM.Application.ViewModels.Pessoa;
using CRM.Domain.Interfaces;
using CRM.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq.Expressions;

namespace CRM.Application.Tests
{
    public class PessoaServiceTests
    {
        private PessoaService pessoaService;

        public PessoaServiceTests()
        {
            var pessoaRepositoryMock = new Mock<IPessoaRepository>();
            var mapperMock = new Mock<IMapper>();
            var controladorPessoaServiceMock = new Mock<IControladorPessoaService>();

            pessoaService = new PessoaService(pessoaRepositoryMock.Object, mapperMock.Object, controladorPessoaServiceMock.Object);
        }

        [Fact]
        public void GetAll_DeveRetornarListaDePessoas()
        {
            // Arrange
            List<Pessoa> _pessoas = new List<Pessoa>
            {
                new Pessoa { Id = Guid.NewGuid(), Nome = "Pedro Palmuti", Email = "palmutip@hotmail.com", DataInclusao = DateTime.Now,DocumentoTipo = 1, Documento = "123", Tipo = 1, Telefone = "123" }
            };

            var _pessoaRepository = new Mock<IPessoaRepository>();
            _pessoaRepository.Setup(x => x.Query(x => !x.IsDeleted)).Returns(_pessoas.AsQueryable());

            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            pessoaService = new PessoaService(_pessoaRepository.Object, _mapper, null);

            // Act
            var result = pessoaService.GetAll();

            // Assert
            Assert.NotEmpty(result);
            Assert.IsType<List<PessoaViewModel>>(result);
        }

        [Fact]
        public void GetById_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => pessoaService.GetById(""));
            Assert.Equal("ID da Pessoa é inválido!", exception.Message);
        }

        [Fact]
        public void GetById_ConsultandoPessoaInexistente()
        {
            var exception = Assert.Throws<Exception>(() => pessoaService.GetById(Guid.NewGuid().ToString()));
            Assert.Equal("Pessoa não encontrada", exception.Message);
        }

        [Fact]
        public void GetById_ComIdValido_DeveRetornarPessoaViewModel()
        {
            // Arrange
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);


            var pessoaFicticia = new Pessoa { Nome = "Pedro Palmuti", Email = "palmutip@hotmail.com", DataInclusao = DateTime.Now, DocumentoTipo = 1, Documento = "123", Tipo = 1, Telefone = "123" };
            var pessoaRepositoryMock = new Mock<IPessoaRepository>();
            pessoaRepositoryMock.Setup(repo => repo.Find(It.IsAny<Expression<Func<Pessoa, bool>>>())).Returns(pessoaFicticia);
            pessoaService = new PessoaService(pessoaRepositoryMock.Object, _mapper, null);

            // Act
            var result = pessoaService.GetById(Guid.NewGuid().ToString());

            // Arrange
            Assert.NotNull(result);
            Assert.IsType<PessoaViewModel>(result);
        }

        
    }

}
