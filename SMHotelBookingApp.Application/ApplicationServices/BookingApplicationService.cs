using SMHotelBookingApp.Application.Dtos;
using SMHotelBookingApp.Application.Interfaces;
using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;

namespace SMHotelBookingApp.Application.ApplicationServices;


public class BookingApplicationService : IBookingApplicationService
{
    private readonly IGenericRepository<Booking> _bookingRepository;
    private readonly IGenericRepository<Room> _roomRepository;
    public BookingApplicationService(IGenericRepository<Booking> bookingRepository, IGenericRepository<Room> roomRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
    }
    public bool CreateBooking(BookingDto dto)
    {
        int roomId = FindAvailableRoom(dto.StartDate, dto.EndDate);

        if (roomId >= 0)
        {
            _bookingRepository.Add(DtoToDomain.BookingDtoToDomain(dto));
            return true;
        }
        else
        {
            return false;
        }
    }

    public int FindAvailableRoom(DateTime startDate, DateTime endDate)
    {
        if (startDate <= DateTime.Today || startDate > endDate)
            throw new ArgumentException("The start date cannot be in the past or later than the end date.");

        var activeBookings = _bookingRepository.GetAll().Where(b => b.IsActive);
        foreach (var room in _roomRepository.GetAll())
        {
            var activeBookingsForCurrentRoom = activeBookings.Where(b => b.RoomId == room.Id);
            if (activeBookingsForCurrentRoom.All(b => startDate < b.StartDate &&
                endDate < b.StartDate || startDate > b.EndDate && endDate > b.EndDate))
            {
                return room.Id;
            }
        }
        return -1;
    }

    public List<DateTime> GetFullyOccupiedDates(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
            throw new ArgumentException("The start date cannot be later than the end date.");

        List<DateTime> fullyOccupiedDates = new();
        int noOfRooms = _roomRepository.GetAll().Count();
        var bookings = _bookingRepository.GetAll();

        if (bookings.Any())
        {
            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                var noOfBookings = from b in bookings
                                   where b.IsActive && d >= b.StartDate && d <= b.EndDate
                                   select b;
                if (noOfBookings.Count() >= noOfRooms)
                    fullyOccupiedDates.Add(d);
            }
        }
        return fullyOccupiedDates;
    }

}
