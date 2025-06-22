using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Appointment.EF;
using Appointment.Models;
using Appointment.ViewModels;

namespace Appointment.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }
         
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.UniqueId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(BookingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate Customer and Service exist
            var customer = await _context.Customers.FindAsync(model.CustomerId);
            var service = await _context.Services.FindAsync(model.ServiceId);

            if (customer == null)
                return BadRequest("Customer not found");

            if (service == null)
                return BadRequest("Service not found");

            var booking = new Booking
            {
                ServiceId = model.ServiceId,
                CustomerId = model.CustomerId,
                StartedDate = model.StartedDate,
                StartedTime = model.StartedTime,
                EndedDate = DateTime.Now 
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.UniqueId }, booking);
        }


        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.UniqueId == id);
        }
    }
}
