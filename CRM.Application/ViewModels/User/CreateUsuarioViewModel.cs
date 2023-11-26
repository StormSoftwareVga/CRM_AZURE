using System.ComponentModel.DataAnnotations;

namespace CRM.Application.ViewModels.User
{
    public class CreateUsuarioViewModel 
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
