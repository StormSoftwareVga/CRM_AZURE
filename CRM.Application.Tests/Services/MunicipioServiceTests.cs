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
using CRM.Application.Services;
using AutoMapper;
using CRM.Application.ViewModels;
using System.ComponentModel.DataAnnotations;
using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Municipio;

namespace CRM.Application.Tests.Services
{
    public class MunicipioServiceTests
    {
        private MunicipioService municipioService;

        public MunicipioServiceTests()
        {
            municipioService = new MunicipioService(new Mock<IMapper>().Object, new Mock<IMunicipioRepository>().Object);
        }

        [Fact]
        public void GetById_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => municipioService.GetById(""));
            Assert.Equal("ID do Municipio é inválido!", exception.Message);
        }

        [Fact]
        public void Put_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => municipioService.Put(new MunicipioViewModel()));
            Assert.Equal("ID do Municipio é inválido!", exception.Message);
        }

        [Fact]
        public void Delete_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => municipioService.Delete(""));
            Assert.Equal("ID do Municipio é inválido!", exception.Message);
        }

        [Fact]
        public void Post_EnviandoObjetoValido()
        {
            var resultado = municipioService.Post(new MunicipioViewModel { Nome = "Varginha", Estado = "Minas Gerais"});
            Assert.True(resultado);
        }

        [Fact]
        public void Get_ValidandoObjeto()
        {
            //Criando uma lista com um obj para que seja retornado pelo repository
            IEnumerable<Municipio> _municipio = new List<Municipio>
            {
                new Municipio{Id = Guid.NewGuid(), Nome = "Varginha" , Estado = new Estado(){Nome = "Minas Gerais", Sigla = "MG", Regiao = new Regiao(){ }, Pais = new Pais(){ Nome = "Brasil" } } ,DataInclusao = DateTime.Now },
                new Municipio{Id = Guid.NewGuid(), Nome = "Eloi Mendes" , Estado = new Estado(){Nome = "Minas Gerais", Sigla = "MG", Regiao = new Regiao(){ }, Pais = new Pais(){ Nome = "Brasil" } } ,DataInclusao = DateTime.Now },
                new Municipio{Id = Guid.NewGuid(), Nome = "Três Corações" , Estado = new Estado(){Nome = "Minas Gerais", Sigla = "MG", Regiao = new Regiao(){ }, Pais = new Pais(){ Nome = "Brasil" } } ,DataInclusao = DateTime.Now }
            };
            //Criando um objeto mock do PaisRepository e configurando para retornar a lista criada
            var _municipioRepository = new Mock<IMunicipioRepository>();
            // _municipioRepository.Setup(x => x.GetAll()).Returns(_municipio);
            _municipioRepository.Setup(x => x.Query(x => !x.IsDeleted)).Returns(_municipio.AsQueryable());
           

            // Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<PaisViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            municipioService = new MunicipioService(_mapper, _municipioRepository.Object);

            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = municipioService.GetAll();

            //Convertendo o resultado para boolean
            bool resultado = result.Count() != 0;

            //Validando se o retorno contém uma lista com objetos.
            Assert.True(resultado);



        }
        [Fact]
        public void Post_EnviandoObjetoInvalido()
        {
            var exception = Assert.Throws<ValidationException>(() => municipioService.Post(new MunicipioViewModel { Nome = "", Estado = "" }));
            Assert.Contains("field is required.", exception.Message);
        }
    }
}
