using SMHotelBookingApp.Application.Dtos;

namespace SMHotelBookingApp.Application.Interfaces;

public interface IBookingApplicationService
{
    bool CreateBooking(BookingDto dto);
    int FindAvailableRoom(DateTime startDate, DateTime endDate);
    List<DateTime> GetFullyOccupiedDates(DateTime startDate, DateTime endDate);
}
