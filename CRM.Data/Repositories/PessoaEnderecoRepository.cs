using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class PessoaEnderecoRepository : Repository<PessoaEndereco>, IPessoaEnderecoRepository
    {
        public PessoaEnderecoRepository(CRMDbContext context) : base(context)
        {
        }
    }
}
