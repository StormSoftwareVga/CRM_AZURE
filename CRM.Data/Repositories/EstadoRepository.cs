﻿using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(CRMDbContext context) : base(context)
        {
        }

        public IEnumerable<Estado> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
