using CRM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.PessoaEndereco
{
    public class PessoaEnderecoViewModel : EntityIdViewModel
    {
        [Required]
        public string Pessoa { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Municipio { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }
    }
}
