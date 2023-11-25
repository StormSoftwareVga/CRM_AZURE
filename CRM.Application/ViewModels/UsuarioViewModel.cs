using System.ComponentModel.DataAnnotations;

namespace CRM.Application
{
    public class UsuarioViewModel : EntityViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
