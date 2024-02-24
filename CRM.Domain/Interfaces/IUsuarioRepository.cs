using System.Collections.Generic;

namespace CRM.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAll(int? page = 0, int? pageSize = 0);
    }
}
