using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface IPaisRepository : IRepository<Pais>
    {
        IEnumerable<Pais> GetAll(int? page = 0, int? pageSize = 0);

        Pais? GetByName(string name);

    }
}
