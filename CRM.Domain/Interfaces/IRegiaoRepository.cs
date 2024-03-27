using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface IRegiaoRepository : IRepository<Regiao>
    {
        Regiao? GetData(string nome, string sigla, string pais);

        IEnumerable<Regiao> GetAll();

        Regiao GetById(Guid id);

        Regiao GetByName(string nome);
    }
}
