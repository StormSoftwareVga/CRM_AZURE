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
        public IEnumerable<Pais> GetAll(int? page = 0, int? pageSize = 0)
        {
            try
            {
                return (from pais in _context.Set<Pais>().AsQueryable()
                        where pais.IsDeleted == false
                        select pais).DataPaged(page, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Pais? GetByName(string name)
        {
            try
            {
                return (from pais in _context.Set<Pais>().AsQueryable()
                        where pais.IsDeleted == false && pais.Nome == name
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
