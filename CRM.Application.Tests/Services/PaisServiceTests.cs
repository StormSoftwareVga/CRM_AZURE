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

namespace CRM.Application.Tests.Services
{
    public class PaisServiceTests
    {
        private PaisService paisService;

        public PaisServiceTests()
        {
            paisService = new PaisService(new Mock<IPaisRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void GetById_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => paisService.GetById(""));
            Assert.Equal("ID do Pais é inválido!", exception.Message);
        }

        [Fact]
        public void Put_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => paisService.Put(new PaisViewModel()));
            Assert.Equal("ID do Pais é inválido!", exception.Message);
        }

        [Fact]
        public void Delete_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => paisService.Delete(""));
            Assert.Equal("ID do Pais é inválido!", exception.Message);
        }

        [Fact]
        public void Post_EnviandoObjetoValido()
        {
            var resultado = paisService.Post(new PaisViewModel { Nome = "Brasil" });
            Assert.True(resultado);
        }

        [Fact]
        public void Get_ValidandoObjeto()
        {
            //Criando uma lista com um obj para que seja retornado pelo repository
            IEnumerable<Pais> _pais = new List<Pais>
            {
                new Pais{Id = Guid.NewGuid(), Nome = "Brasil", DataInclusao = DateTime.Now },
                new Pais{Id = Guid.NewGuid(), Nome = "Argentina", DataInclusao = DateTime.Now },
                new Pais{Id = Guid.NewGuid(), Nome = "Dinamarca", DataInclusao = DateTime.Now }
            };
            //Criando um objeto mock do PaisRepository e configurando para retornar a lista criada
            var _paisRepository = new Mock<IPaisRepository>();
            _paisRepository.Setup(x => x.Query(x => !x.IsDeleted)).Returns(_pais.AsQueryable());

            // Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<PaisViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            paisService = new PaisService(_paisRepository.Object, _mapper);

            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = paisService.GetAll();

            //Convertendo o resultado para boolean
            bool resultado = result.Count() != 0;

            //Validando se o retorno contém uma lista com objetos.
            Assert.True(resultado);



        }
        [Fact]
        public void Post_EnviandoObjetoInvalido()
        {
            var exception = Assert.Throws<ValidationException>(() => paisService.Post(new PaisViewModel { Nome = "" }));
            Assert.Contains("field is required.", exception.Message);
        }
    }
}
