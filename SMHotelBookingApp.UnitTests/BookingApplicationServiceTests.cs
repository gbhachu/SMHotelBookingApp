using SMHotelBookingApp.Application.ApplicationServices;
using SMHotelBookingApp.Application.Interfaces;
using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;
using SMHotelBookingApp.UnitTests.Moqs;

namespace SMHotelBookingApp.UnitTests
{
    public class BookingApplicationServiceTests
    {
        private IBookingApplicationService _bookingApplicationService;

        public BookingApplicationServiceTests()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);
            IGenericRepository<Booking> bookingRepository = new MoqBookingRepository(start, end);
            IGenericRepository<Room> roomRepository = new MoqRoomRepository();
            _bookingApplicationService = new BookingApplicationService(bookingRepository, roomRepository);
        }

        [Fact]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            // Arrange
            DateTime date = DateTime.Today;

            // Act
            void act() => _bookingApplicationService.FindAvailableRoom(date, date);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        {
            // Arrange
            DateTime date = DateTime.Today.AddDays(1);
            // Act
            int roomId = _bookingApplicationService.FindAvailableRoom(date, date);
            // Assert
            Assert.NotEqual(-1, roomId);
        }
    }
}
