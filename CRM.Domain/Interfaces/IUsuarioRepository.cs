using System;
using System.Collections.Generic;

namespace CRM.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAll();
        public Usuario GetById(Guid id);
        Usuario GetByEmail(string email);

    }
}
