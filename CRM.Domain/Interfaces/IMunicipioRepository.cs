using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface IMunicipioRepository : IRepository<Municipio>
    {
        IEnumerable<Municipio> GetAll(int? page = 0, int? pageSize = 0);
    }
}
