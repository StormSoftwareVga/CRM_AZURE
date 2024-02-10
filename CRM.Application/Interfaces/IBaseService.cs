using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application
{
    public interface IBaseService<TEntity, TViewModel>
    {
        IEnumerable<TViewModel> GetAll(int? page = 0, int? pageSize = 0);
        TViewModel GetById(string id);
        //bool Post(TViewModel viewModel);
        bool Put(TViewModel viewModel);
        bool Delete(string id);
    }
}
