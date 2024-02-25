﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        IEnumerable<Pessoa> GetAll();

        public Pessoa GetById(Guid id);
    }
}
