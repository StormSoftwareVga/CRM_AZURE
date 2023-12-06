using CRM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels
{
    public class RegiaoViewModel : EntityIdViewModel
    {
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sigla { get; set; }
    }
}
