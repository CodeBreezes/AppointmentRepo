using System.ComponentModel.DataAnnotations;

namespace Appointment.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateOnly Date { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
