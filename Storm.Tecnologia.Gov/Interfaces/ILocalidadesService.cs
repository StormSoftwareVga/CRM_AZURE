using Storm.Tecnologia.Gov.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storm.Tecnologia.Gov.Interfaces
{
    public interface ILocalidadesService
    {
        Task<EstadoModel> GetEstado(string UF);
        Task<List<EstadoModel>> GetEstados();
    }
}