using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Models
{
    public class Booking
    {
        [Key]
        public int UniqueId { get; set; }
 
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Services Service { get; set; } = null!;

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]

        public Customer Customer { get; set; } = null!;
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }

    }
}
