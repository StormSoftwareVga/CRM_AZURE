using CRM.Domain.Interfaces;
using Storm.Tecnologia.Gov.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CRM.Domain.Services
{
    public class ControladorPessoaService : IControladorPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IPaisRepository paisRepository;
        private readonly IRegiaoRepository regiaoRepository;
        private readonly IEstadoRepository estadoRepository;
        private readonly IMunicipioRepository municipioRepository;
        private readonly IPessoaEnderecoRepository pessoaEnderecoRepository;
        private readonly IReceitawsService receitawsService;
        private readonly ILocalidadesService localidadesService;

        public ControladorPessoaService(IPessoaRepository pessoaRepository, IPaisRepository paisRepository, IRegiaoRepository regiaoRepository, IEstadoRepository estadoRepository, IMunicipioRepository municipioRepository, IPessoaEnderecoRepository pessoaEnderecoRepository, IReceitawsService receitawsService, ILocalidadesService localidadesService)
        {
            this.receitawsService = receitawsService;
            this.pessoaRepository = pessoaRepository;
            this.localidadesService = localidadesService;
            this.paisRepository = paisRepository;
            this.regiaoRepository = regiaoRepository;
            this.estadoRepository = estadoRepository;
            this.municipioRepository = municipioRepository;
            this.pessoaEnderecoRepository = pessoaEnderecoRepository;
        }

        public async Task<bool> CadastrarNovoLead(Pessoa pessoa)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    pessoaRepository.Create(pessoa);

                    if (pessoa.Tipo == PessoaTipoListaItens.ItemPessoaJuridica.Index && pessoa.DocumentoTipo == DocumentoTipoListaItens.ItemCNPJ.Index)
                    {
                        var dadosCNPJ = await receitawsService.ConsultaCnpj(pessoa.Documento);

                        var pais = new Pais() { Nome = "Brasil" };

                        var estadoLocalidade = await localidadesService.GetEstado(dadosCNPJ.uf);

                        var regiao = new Regiao() { Nome = estadoLocalidade.regiao.nome, Sigla = estadoLocalidade.regiao.sigla, Pais = pais };

                        var estado = new Estado() { Nome = estadoLocalidade.nome, Pais = pais, Regiao = regiao, Sigla = estadoLocalidade.sigla };

                        var municipio = new Municipio() { Nome = dadosCNPJ.municipio, Estado = estado };

                        var pessoaEndereco = new PessoaEndereco()
                        {
                            Pessoa = pessoa,
                            CEP = dadosCNPJ.cep,
                            Pais = pais,
                            Estado = estado,
                            Municipio = municipio,
                            Bairro = dadosCNPJ.bairro,
                            Logradouro = dadosCNPJ.logradouro,
                            Numero = dadosCNPJ.numero
                        };

                        if (paisRepository.Query(x => !x.IsDeleted && x.Nome == pais.Nome).Count() == 0)
                            paisRepository.Create(pais);

                        if (regiaoRepository.Query(x => !x.IsDeleted && x.Nome == regiao.Nome && x.Sigla == regiao.Sigla && x.Pais.Nome == regiao.Pais.Nome).Count() == 0)
                            regiaoRepository.Create(regiao);

                        if (estadoRepository.Query(x => !x.IsDeleted && x.Nome == estado.Nome && x.Sigla == estado.Sigla && x.Regiao.Nome == estado.Regiao.Nome && x.Pais.Nome == estado.Pais.Nome).Count() == 0)
                            estadoRepository.Create(estado);

                        if (municipioRepository.Query(x => !x.IsDeleted && x.Nome == municipio.Nome && x.Estado.Sigla == municipio.Estado.Sigla).Count() == 0)
                            municipioRepository.Create(municipio);

                        if (pessoaEnderecoRepository.Query(x => !x.IsDeleted
                            && x.Pais.Nome == pessoaEndereco.Pais.Nome
                            && x.CEP == pessoaEndereco.CEP
                            && x.Estado.Sigla == pessoaEndereco.Estado.Sigla
                            && x.Municipio.Nome == pessoaEndereco.Municipio.Nome
                            && x.Bairro == pessoaEndereco.Bairro
                            && x.Logradouro == pessoaEndereco.Logradouro
                            && x.Numero == pessoaEndereco.Numero)
                            .Count() == 0)
                            pessoaEnderecoRepository.Create(pessoaEndereco);
                    }
                    else
                        throw new Exception("Não é possivel cadastrar outros tipos de documento além de CNPJ. Aguarde novas atualizações do sistema.");

                    scope.Complete(); 

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }
    }
}
