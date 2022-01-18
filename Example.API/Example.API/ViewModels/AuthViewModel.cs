using System.ComponentModel.DataAnnotations;

namespace Example.API.ViewModels
{
    public class AuthViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}