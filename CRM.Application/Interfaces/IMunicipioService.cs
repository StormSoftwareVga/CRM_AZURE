using CRM.Application.ViewModels.Municipio;
using CRM.Application.ViewModels.PessoaEndereco;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IMunicipioService : IBaseService<Municipio, MunicipioViewModel>
    {
        bool Post(MunicipioViewModel viewModel);
    }
}
