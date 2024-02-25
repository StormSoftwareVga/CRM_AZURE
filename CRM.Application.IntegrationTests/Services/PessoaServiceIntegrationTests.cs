using AutoMapper;
using CRM.Application.ViewModels.Pessoa;
using CRM.Data;
using CRM.Domain.Services;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Transactions;

namespace CRM.Application.IntegrationTests.Services
{
    public class PessoaServiceIntegrationTests
    {
        private IHost host;
        private readonly PessoaService _service;

        public PessoaServiceIntegrationTests()
        {
            _service = new PessoaService(new PessoaRepository(DbContextOptionsBuilderForTests.ContextoDoBancoDeDados()), new Mapper(new MapperConfiguration(x => x.AddProfile(new AutoMapperSetup()))), new ControladorPessoaService(null, null, null, null, null, null, null, null));
        }

        [SetUp]
        public void Setup()
        {
            host = IniciarTestes.Start().Build();
            host.Start();
        }

        [TearDown]
        public void TearDown()
        {
            host.Dispose();
        }

        [Test]
        public void CadastrarCnpjs()
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var diretorioTestes = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
                string jsonContent = File.ReadAllText(Path.Combine(diretorioTestes ?? AppDomain.CurrentDomain.BaseDirectory, "Includes/listaCnpjs.json"));

                var pessoas = JsonSerializer.Deserialize<List<PessoaViewModel>>(jsonContent);

                foreach (var pessoa in pessoas)
                {
                    _service.Post(pessoa);
                }

                scope.Complete();
            }
        }
    }
}