using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.Municipio
{
    public class MunicipioViewModel : EntityIdViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
