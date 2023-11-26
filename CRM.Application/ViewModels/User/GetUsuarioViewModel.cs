using System.ComponentModel.DataAnnotations;

namespace CRM.Application.ViewModels.User
{
    public class GetUsuarioViewModel : EntityViewModel
    { 
        public string Nome { get; set; } 
        public string Email { get; set; } 
    }
}
