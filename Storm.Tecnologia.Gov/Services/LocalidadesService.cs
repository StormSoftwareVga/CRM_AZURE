using Newtonsoft.Json;
using Storm.Tecnologia.Gov.Interfaces;
using Storm.Tecnologia.Gov.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Tecnologia.Gov.Services
{
    public class LocalidadesService : BaseService, ILocalidadesService
    {
        private const string url = "https://servicodados.ibge.gov.br/api/v1/localidades/";

        public async Task<List<EstadoModel>> GetEstados()
        {
            return await ChamarAPI<List<EstadoModel>>(url, "estados");
        }

        public async Task<EstadoModel> GetEstado(string UF)
        {
            return await ChamarAPI<EstadoModel>(url, "estados/" + UF);
        }
    }
}
