using CRM.Domain;
using CRM.Domain.Core;
using CRM.Domain.Interfaces;
using CRM.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class PaisRepository : Repository<Pais>, IPaisRepository
    {
        public PaisRepository(CRMDbContext context) : base(context)
        {

        }
        public IEnumerable<Pais> GetAll()
        {
            try
            {
                return (from pais in _context.Set<Pais>().AsQueryable()
                        where pais.IsDeleted == false
                        select pais);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Pais GetById(Guid id)
        {
            try
            {
                return(from pais in _context.Set<Pais>().AsQueryable()
                       where pais.IsDeleted == false && id == pais.Id
                       select pais).FirstOrDefault();

            }
            catch(Exception ex)
            {
                Log.Error(ex);
                   throw ex;
            }

        }

        public Pais GetByName(string nome)
        {
            try
            {
                return (from pais in _context.Set<Pais>().AsQueryable()
                        where pais.IsDeleted == false && pais.Nome == nome
                        select pais).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

    }
}
