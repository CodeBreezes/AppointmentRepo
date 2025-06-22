using System.ComponentModel.DataAnnotations;

namespace Appointment.ViewModels
{
    public class BookingViewModel
    {
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateOnly StartedDate { get; set; }

        [Required]
        public TimeOnly StartedTime { get; set; }
    }
}
