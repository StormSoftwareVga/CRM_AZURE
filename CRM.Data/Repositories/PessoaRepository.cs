using CRM.Domain;
using CRM.Domain.Core;
using CRM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(CRMDbContext context) : base(context)
        {
        }

        public IEnumerable<Pessoa> GetAll()
        {
            try
            {
                return (from pessoas in _context.Set<Pessoa>().AsQueryable()
                        where pessoas.IsDeleted == false
                        select pessoas);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
        public Pessoa GetById(Guid id)
        {
            try
            {
                return (from pessoas in _context.Set<Pessoa>().AsQueryable()
                                 where pessoas.IsDeleted == false && id == pessoas.Id
                                 select pessoas).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Pessoa GetByDocument(string documento)
        {
            try
            {
                documento = documento.Replace(".", "").Replace("-", "").Replace("/", "");

                return (from pessoas in _context.Set<Pessoa>().AsQueryable()
                        where pessoas.IsDeleted == false && pessoas.Documento == documento
                        select pessoas).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
