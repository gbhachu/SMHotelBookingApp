using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMHotelBookingApp.Application.Dtos;
using SMHotelBookingApp.Application.Interfaces;
using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;

namespace SMHotelBookingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IBookingApplicationService _bookingAppService;

        public BookingController(IUnitOfWork unitOfWork, IBookingApplicationService bookingApplicationService)
        {
            _unitOfWork = unitOfWork;
            _bookingAppService = bookingApplicationService;
        }


        // GET: bookings
        [HttpGet(Name = "GetBookings")]
        public IEnumerable<Booking> Get()
        {
            return _unitOfWork.Booking.GetAll();
        }

        // GET bookings/5
        [HttpGet("{id}", Name = "GetBooking")]
        public IActionResult Get(int id)
        {
            var item = _unitOfWork.Booking.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST bookings
        [HttpPost]
        public IActionResult Post([FromBody] BookingDto booking)
        {
            if (booking == null)
            {
                return BadRequest();
            }

            var created = _bookingAppService.CreateBooking(booking);

            if (created)
            {
                return CreatedAtRoute("GetBookings", null);
            }
            else
            {
                return Conflict("The booking could not be created. All rooms are occupied. Please try another period.");
            }

        }

        // PUT bookings/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Booking booking)
        {
            if (booking == null || booking.Id != id)
            {
                return BadRequest();
            }

            var modifiedBooking = _unitOfWork.Booking.Get(id);

            if (modifiedBooking == null)
            {
                return NotFound();
            }

            // This implementation will only modify the booking's state and customer.
            // It is not safe to directly modify StartDate, EndDate and Room, because
            // it could conflict with other active bookings.
            modifiedBooking.IsActive = booking.IsActive;
            modifiedBooking.Customer.Id = booking.Customer.Id;

            _unitOfWork.Booking.Edit(modifiedBooking);
            return NoContent();
        }

        // DELETE bookings/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Booking booking)
        {
            if (_unitOfWork.Booking.Get(booking.Id) == null)
            {
                return NotFound();
            }

            _unitOfWork.Booking.Remove(booking);
            return NoContent();
        }
    }
}
