using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Utils;
using CRM.Domain.Core;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CRM.Application.ViewModels.Estado;

namespace CRM.Data.Repositories
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(CRMDbContext context) : base(context)
        {
        }

        public IEnumerable<Estado> GetAll()
        {
            try
            {
                return (from estados in _context.Set<Estado>().AsQueryable()
                        where estados.IsDeleted == false
                        select estados);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Estado GetById(Guid id)
        {
            try
            {
                return (from estados in _context.Set<Estado>().AsQueryable()
                        where estados.IsDeleted == false && id == estados.Id
                        select estados).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Estado GetByName(string nome)
        {
            try
            {


               return (from estados in _context.Set<Estado>().AsQueryable()
                             where estados.Nome == nome
                             select estados).FirstOrDefault();

            }
            catch (Exception ex)
            {

                Log.Error(ex);
                throw ex;

            }
        }

        

       

        public Estado? GetData(string nome, string pais, string regiao, string sigla)
        {
            try
            {
                return (from estado in _context.Set<Estado>().AsQueryable()
                        where estado.IsDeleted == false 
                        && estado.Nome == nome 
                        && estado.Pais.Nome == pais
                        && estado.Regiao.Nome == regiao
                        && estado.Sigla == sigla
                        select estado).FirstOrDefault();
            }
            catch(Exception ex) 
            { 
            Log.Error(ex);
            throw ex;
            }
        }
    }
}
