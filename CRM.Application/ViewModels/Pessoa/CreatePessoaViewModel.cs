using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.Pessoa
{
    public class CreatePessoaViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Tipo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int DocumentoTipo { get; set; }
        public string Documento { get; set; }
    }
}
