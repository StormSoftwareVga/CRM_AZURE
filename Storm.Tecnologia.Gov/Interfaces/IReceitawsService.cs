using Storm.Tecnologia.Gov.Models;
using System.Threading.Tasks;

namespace Storm.Tecnologia.Gov.Interfaces
{
    public interface IReceitawsService
    {
        Task<CnpjModel> ConsultaCnpj(string Cnpj);
    }
}