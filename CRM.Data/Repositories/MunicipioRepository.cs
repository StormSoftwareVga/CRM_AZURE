using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Utils;
using CRM.Domain.Core;

namespace CRM.Data.Repositories
{
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(CRMDbContext context) : base(context)
        {

        }
        public IEnumerable<Municipio> GetAll(int? page = 0, int? pageSize = 0)
        {
            try
            {
                return (from municipio in _context.Set<Municipio>().AsQueryable()
                        where municipio.IsDeleted == false
                        select municipio).DataPaged(page, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
