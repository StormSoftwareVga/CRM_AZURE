using Newtonsoft.Json;
using Storm.Tecnologia.Gov.Interfaces;
using Storm.Tecnologia.Gov.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Storm.Tecnologia.Gov.Services
{
    public class ReceitawsService : BaseService, IReceitawsService
    {
        private const string url = "http://receitaws.com.br/v1/cnpj/";
        public async Task<CnpjModel> ConsultaCnpj(string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            return await ChamarAPI<CnpjModel>(url, cnpj);
        }
    }
}
