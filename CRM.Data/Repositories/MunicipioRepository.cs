using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(CRMDbContext context) : base(context)
        {

        }
        public IEnumerable<Municipio> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
