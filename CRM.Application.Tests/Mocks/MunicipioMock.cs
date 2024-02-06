using CRM.Application.Interfaces;
using CRM.Application.ViewModels.Municipio;
using CRM.Domain;
using CRM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Tests.Mocks
{
    public class MunicipioMock : IMunicipioService
    {
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MunicipioViewModel> GetAll()
        {
            var _municipio = new List<MunicipioViewModel>
            {
                new MunicipioViewModel{Nome = "Varginha" , Estado  = "Minas Gerais"},
                //new Municipio{Id = Guid.NewGuid(), Nome = "Eloi Mendes" , Estado = new Estado(){Nome = "Minas Gerais", Sigla = "MG", Regiao = new Regiao(){ }, Pais = new Pais(){ Nome = "Brasil" } } ,DataInclusao = DateTime.Now },
                //new Municipio{Id = Guid.NewGuid(), Nome = "Três Corações" , Estado = new Estado(){Nome = "Minas Gerais", Sigla = "MG", Regiao = new Regiao(){ }, Pais = new Pais(){ Nome = "Brasil" } } ,DataInclusao = DateTime.Now }
            }.AsEnumerable();

            return _municipio;
        }

        public MunicipioViewModel GetById(string id)
        {*
            throw new NotImplementedException();
        }

        public bool Post(MunicipioViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public bool Put(MunicipioViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
