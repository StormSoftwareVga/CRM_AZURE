using System;
using System.Collections.Generic;

namespace CRM.Domain
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        IEnumerable<Pessoa> GetAll();

        public Pessoa GetById(Guid id);

        Pessoa GetByDocument(string documento);

    }
}
