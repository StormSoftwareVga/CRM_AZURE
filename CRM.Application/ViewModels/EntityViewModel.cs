using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels
{
    public class EntityViewModel : EntityIdViewModel
    {
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
