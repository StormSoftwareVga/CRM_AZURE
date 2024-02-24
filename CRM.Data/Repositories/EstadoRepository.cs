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
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(CRMDbContext context) : base(context)
        {
        }

        public IEnumerable<Estado> GetAll(int? page = 0, int? pageSize = 0)
        {
            try
            {
                return (from estado in _context.Set<Estado>().AsQueryable()
                        where estado.IsDeleted == false
                        select estado).DataPaged(page, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
