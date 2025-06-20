using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Appointment.Models
{

    public class AppUser
    {
        [Key]
        [Display(Name = "Unique ID")]
        public int UniqueId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [MaxLength(15)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50)]
        public string? Gender { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        [NotMapped]
        public string Password { get; set; }

        //[NotMapped]
        //[Compare("Password")]
        //public string ConfermPassword { get; set; }




        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public List<int> Roles { get; set; } = new List<int>();
    }
}
