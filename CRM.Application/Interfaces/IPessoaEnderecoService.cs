using CRM.Application.ViewModels;
using CRM.Application.ViewModels.PessoaEndereco;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IPessoaEnderecoService : IBaseService<PessoaEndereco, PessoaEnderecoViewModel>
    {
        bool Post(PessoaEnderecoViewModel viewModel);
    }
}
