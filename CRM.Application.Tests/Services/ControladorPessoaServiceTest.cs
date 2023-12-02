using AutoMapper;
using CRM.Application.Tests.Mocks;
using CRM.Application.ViewModels.User;
using CRM.Domain;
using CRM.Domain.Interfaces;
using CRM.Domain.Services;
using Moq;
using Storm.Tecnologia.Gov.Interfaces;
using Storm.Tecnologia.Gov.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRM.Application.Tests
{
    public class ControladorPessoaServiceTest
    {
        private ControladorPessoaService controladorPessoaService;

        public ControladorPessoaServiceTest()
        {
            controladorPessoaService = new ControladorPessoaService(new Mock<IPessoaRepository>().Object, new Mock<IPaisRepository>().Object, new Mock<IRegiaoRepository>().Object, new Mock<IEstadoRepository>().Object, new Mock<IMunicipioRepository>().Object, new Mock<IPessoaEnderecoRepository>().Object,  new ReceitaWSCNPJValidoMock() , new LocalidadesValidasMock() );
        }

        [Fact]
        public async void CadastrarNovoLead()
        {
            var pessoa = new Pessoa()
            {
                Nome = "Pedro",
                Email = "palmutip@hotmail.com",
                Documento = "35.999.633/0001-30",
                DocumentoTipo = DocumentoTipoListaItens.ItemCNPJ,
                Tipo = PessoaTipoListaItens.ItemPessoaJuridica,
                Telefone = "35 9999 - 9999"
            };
            
            Assert.True(await controladorPessoaService.CadastrarNovoLead(pessoa));
        }

        [Fact]
        public async void DocumentoTipoInvalidoAoCadastrarLead()
        {
            var pessoa = new Pessoa()
            {
                Nome = "Pedro",
                Email = "palmutip@hotmail.com",
                Documento = "35.999.633/0001-30",
                DocumentoTipo = 0,
                Tipo = PessoaTipoListaItens.ItemPessoaJuridica,
                Telefone = "35 9999 - 9999"
            };

            var exception = await Assert.ThrowsAsync<Exception>(async () => await controladorPessoaService.CadastrarNovoLead(pessoa));
            Assert.Equal("Não é possivel cadastrar outros tipos de documento além de CNPJ. Aguarde novas atualizações do sistema.", exception.Message);
        }
    }
}
