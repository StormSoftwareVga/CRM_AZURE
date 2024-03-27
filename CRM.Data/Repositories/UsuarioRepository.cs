using CRM.Domain;
using CRM.Domain.Core;
using CRM.Domain.Interfaces;
using CRM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CRMDbContext context) : base(context)
        {

        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                return (from usuarios in _context.Set<Usuario>().AsQueryable()
                        where usuarios.IsDeleted == false
                        select usuarios);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Usuario GetById(Guid id)
        {
            try
            {
                return (from usuarios in _context.Set<Usuario>().AsQueryable()
                        where usuarios.IsDeleted == false && id == usuarios.Id
                        select usuarios).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Usuario GetByEmail(string email)
        {
            try
            {
                return (from usuarios in _context.Set<Usuario>().AsQueryable()
                        where usuarios.IsDeleted == false && usuarios.Email == email
                        select usuarios).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
