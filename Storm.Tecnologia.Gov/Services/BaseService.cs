using Newtonsoft.Json;
using Storm.Tecnologia.Gov.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Tecnologia.Gov.Services
{
    public abstract class BaseService
    {
        protected async Task<T> ChamarAPI<T>(string url, string parametro)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var dados = await client.GetAsync(url + parametro);

                    if (dados.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<T>(await dados.Content.ReadAsStringAsync());
                    else
                        throw new HttpRequestException($"Falha na chamada à API. Código de status: {dados.StatusCode}");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao chamar a API: {e.Message}");
            }
        }
    }

}
