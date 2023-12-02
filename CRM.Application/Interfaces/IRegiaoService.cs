using CRM.Application.ViewModels;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IRegiaoService : IBaseService<Regiao, RegiaoViewModel>
    {
        bool Post(RegiaoViewModel viewModel);
    }
}
