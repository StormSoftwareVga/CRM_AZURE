using CRM.Domain;
using CRM.Domain.Core;
using CRM.Domain.Interfaces;
using CRM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CRMDbContext context) : base(context)
        {

        }

        public IEnumerable<Usuario> GetAll(int? page = 0, int? pageSize = 0)
        {
            try
            {
                return (from usuario in _context.Set<Usuario>().AsQueryable()
                        where usuario.IsDeleted == false
                        select usuario).DataPaged(page, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
