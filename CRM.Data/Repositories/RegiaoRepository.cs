using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class RegiaoRepository : Repository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(CRMDbContext context) : base(context)
        {
        }
    }
}
