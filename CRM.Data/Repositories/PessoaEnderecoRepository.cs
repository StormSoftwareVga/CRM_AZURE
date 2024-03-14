using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Utils;
using CRM.Domain.Core;

namespace CRM.Data.Repositories
{
    public class PessoaEnderecoRepository : Repository<PessoaEndereco>, IPessoaEnderecoRepository
    {
        public PessoaEnderecoRepository(CRMDbContext context) : base(context)
        {
        }

        public IEnumerable<PessoaEndereco> GetAll()
        {
            try
            {
                return (from pessoaEnderecos in _context.Set<PessoaEndereco>().AsQueryable()
                        where pessoaEnderecos.IsDeleted == false
                        select pessoaEnderecos);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public PessoaEndereco GetById(Guid id)
        {
            try
            {
                return (from pessoaEndereco in _context.Set<PessoaEndereco>().AsQueryable()
                        where pessoaEndereco.IsDeleted == false && id == pessoaEndereco.Id
                        select pessoaEndereco).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
