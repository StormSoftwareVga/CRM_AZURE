using CRM.Application.ViewModels.Pessoa;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IPessoaService : IBaseService<Pessoa,PessoaViewModel>
    {
        bool Post(CreatePessoaViewModel viewModel);
    }
}
