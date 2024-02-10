using CRM.Domain;
using CRM.Domain.Core;
using CRM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(CRMDbContext context) : base(context)
        {
        }

        public IEnumerable<Pessoa> GetAll(int? page = 0, int? pageSize = 0)
        {
            try
            {
                return (from pessoas in _context.Set<Pessoa>().AsQueryable()
                        select pessoas).DataPaged(page, pageSize);
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
