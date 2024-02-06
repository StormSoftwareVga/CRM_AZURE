using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Services;
using CRM.Application.ViewModels.Municipio;
using CRM.Domain.Interfaces;
using CRM.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CRM.Application.ViewModels.Estado;
namespace CRM.Application.Tests.Services
{
    public class EstadoServiceTests
    {

        private EstadoService estadoService;



        public EstadoServiceTests()
        {
            estadoService = new EstadoService(new Mock<IMapper>().Object, new Mock<IEstadoRepository>().Object);
        }

        [Fact]
        public void GetById_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => estadoService.GetById(""));
            Assert.Equal("ID do Estado é inválido!", exception.Message);
        }

        [Fact]
        public void Put_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => estadoService.Put(new EstadoViewModel()));
            Assert.Equal("ID do Estado é inválido!", exception.Message);
        }

        [Fact]
        public void Delete_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => estadoService.Delete(""));
            Assert.Equal("ID do Estado é inválido!", exception.Message);
        }

        [Fact]
        public void Post_EnviandoObjetoValido()
        {
            var resultado = estadoService.Post(new EstadoViewModel { Nome = "Minas Gerais", Sigla = "MG", Regiao = "Sudeste", Pais = "Brazil" });
            Assert.True(resultado);
        }

        [Fact]
        public void Get_ValidandoObjeto()
        {
            //Criando uma lista com um obj para que seja retornado pelo repository
            IEnumerable<Estado> _estado = new List<Estado>
            {
                new Estado{Id = Guid.NewGuid(), Nome = "Minas Gerais" , DataInclusao = DateTime.Now },
                new Estado{Id = Guid.NewGuid(), Nome = "Paraná", DataInclusao = DateTime.Now },
                new Estado{Id = Guid.NewGuid(), Nome = "São Paulo", DataInclusao = DateTime.Now }
            };
            //Criando um objeto mock do PaisRepository e configurando para retornar a lista criada
            var _estadoRepository = new Mock<IEstadoRepository>();
            _estadoRepository.Setup(x => x.Query(x => !x.IsDeleted)).Returns(_estado.AsQueryable());

            // Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<PaisViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            estadoService = new EstadoService(_mapper, _estadoRepository.Object);

            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = estadoService.GetAll();

            //Convertendo o resultado para boolean
            bool resultado = result.Count() != 0;

            //Validando se o retorno contém uma lista com objetos.
            Assert.True(resultado);



        }
        [Fact]
        public void Post_EnviandoObjetoInvalido()
        {
            var exception = Assert.Throws<ValidationException>(() => estadoService.Post(new EstadoViewModel { Nome = "", Sigla= "", Regiao = "", Pais = "" }));
            Assert.Contains("field is required.", exception.Message);
        }
    }
}