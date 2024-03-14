using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface IPaisRepository : IRepository<Pais>
    {
        IEnumerable<Pais> GetAll();

        Pais GetById(Guid id);

        Pais? GetByName(string name);

    }
}
