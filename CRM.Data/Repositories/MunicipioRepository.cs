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
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(CRMDbContext context) : base(context)
        {

        }
        public IEnumerable<Municipio> GetAll()
        {
            try
            {
                return (from municipio in _context.Set<Municipio>().AsQueryable()
                        where municipio.IsDeleted == false
                        select municipio);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
        public Municipio GetById(Guid id)
        {
            try
            {
                return (from municipios in _context.Set<Municipio>().AsQueryable()
                        where municipios.IsDeleted == false && id == municipios.Id
                        select municipios).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
        public Municipio? GetData(string municipioNome, string estado)
        {
            try
            {
                return (from municipio in _context.Set<Municipio>().AsQueryable()
                        where municipio.IsDeleted == false
                        && municipio.Nome == municipioNome
                        && municipio.Estado.Nome == estado
                        select municipio).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
