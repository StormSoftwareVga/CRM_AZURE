using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces
{
    public interface IPessoaEnderecoRepository : IRepository<PessoaEndereco>
    {
        IEnumerable<PessoaEndereco> GetAll();
        public PessoaEndereco GetById(Guid id);
        PessoaEndereco GetByEndereco(string cep, string logradouro, string numero);

    }
}
