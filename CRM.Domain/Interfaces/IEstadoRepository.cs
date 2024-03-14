using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface IEstadoRepository : IRepository<Estado>
    {
        IEnumerable<Estado> GetAll();

        Estado GetById(Guid id);

        Estado? GetData(string nome, string pais, string regiao, string sigla);
    }
}
