﻿using System.Collections.Generic;

namespace CRM.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAll();
    }
}
