using System.Collections.Generic;
using CRM.Domain;

namespace CRM.Data
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CRMDbContext context) : base(context)
        {

        }

        public IEnumerable<Usuario> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
