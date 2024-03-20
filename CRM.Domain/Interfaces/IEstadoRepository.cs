using System;
using System.Collections.Generic;

namespace CRM.Domain.Interfaces
{
    public interface IEstadoRepository : IRepository<Estado>
    {
        IEnumerable<Estado> GetAll();

        Estado GetById(Guid id);

        Estado GetByName(string viewModel);

        Estado? GetData(string nome, string pais, string regiao, string sigla);
    }
}
