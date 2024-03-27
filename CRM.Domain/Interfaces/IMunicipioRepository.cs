using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface IMunicipioRepository : IRepository<Municipio>
    {
        IEnumerable<Municipio> GetAll();

        Municipio GetById(Guid id);

        Municipio GetByName(string nome);

        Municipio? GetData(string municipioId, string estado);

       
    }
}
