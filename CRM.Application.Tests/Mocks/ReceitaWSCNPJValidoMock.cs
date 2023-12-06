using Storm.Tecnologia.Gov.Interfaces;
using Storm.Tecnologia.Gov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Tests.Mocks
{
    public class ReceitaWSCNPJValidoMock : IReceitawsService
    {
        private CnpjModel dadosCNPJ;
        public Task<CnpjModel> ConsultaCnpj(string Cnpj)
        {
            dadosCNPJ = new CnpjModel()
            {
                uf = "MG",
                municipio = "Varginha",
                cep = "37000-100",
                bairro = "Centro",
                logradouro = "Rua numero 1",
                numero = "1234",
            };

            return Task.FromResult(dadosCNPJ);
        }
    }
}
