using CRM.Domain;
using CRM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class PaisRepository : Repository<Pais>, IPaisRepository
    {
        public PaisRepository(CRMDbContext context) : base(context)
        {
        }
    }
}
