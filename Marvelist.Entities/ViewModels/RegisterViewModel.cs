using System.ComponentModel.DataAnnotations;
using Marvelist.Entities.Enums;

namespace Marvelist.Entities.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}