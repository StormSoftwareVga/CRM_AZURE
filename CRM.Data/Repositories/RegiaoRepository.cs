using CRM.Domain.Interfaces;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain.Core;
using System.Xml.Linq;
using CRM.Application.Services;

namespace CRM.Data.Repositories
{
    public class RegiaoRepository : Repository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(CRMDbContext context) : base(context)
        {
        }

        public IEnumerable<Regiao> GetAll()
        {
            try
            {
                return (from regiao in _context.Set<Regiao>().AsQueryable()
                        where regiao.IsDeleted == false
                        select regiao);

            }
            catch (Exception ex)
            {
                Log.Error();
                throw ex;
            }
        }



        public Regiao GetById(Guid id)
        {
            try
            {
                return (from regiao in _context.Set<Regiao>().AsQueryable()
                        where regiao.IsDeleted == false && id == regiao.Id
                        select regiao).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Regiao GetByName(string nome)
        {
            try
            {
                return (from regiao in _context.Set<Regiao>().AsQueryable()
                        where regiao.Nome == nome && regiao.IsDeleted == false
                        select regiao).FirstOrDefault();
            }
            catch(Exception ex) 
            {
                Log.Error(ex);
                throw ex;
            }
        }
        public Regiao? GetData(string nome, string sigla, string pais)
        {
            try
            {
                return (from regiao in _context.Set<Regiao>().AsQueryable()
                        where regiao.IsDeleted == false 
                        && regiao.Nome == nome 
                        && regiao.Sigla == sigla 
                        && regiao.Pais.Nome == pais
                        select regiao).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
