using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.Estado
{
    public class EstadoViewModel : EntityIdViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sigla { get; set; }
        [Required]
        public string Regiao { get; set; }
        [Required]
        public string Pais { get; set; }
    }
}
