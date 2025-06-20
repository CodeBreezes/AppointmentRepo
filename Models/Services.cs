using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Models
{
    public class Services
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public DateOnly Date{ get; set; }
        public string ImagePath { get; set; }
    }
}
