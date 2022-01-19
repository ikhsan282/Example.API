using System.ComponentModel.DataAnnotations;

namespace Example.API.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public Guid PositionID { get; set; }

        [Required]
        public Guid SchoolID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Bio { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}