using Marvelist.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Marvelist.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
        public LoginActions Action { get; set; }
    }
}