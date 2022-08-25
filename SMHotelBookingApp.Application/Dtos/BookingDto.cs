using SMHotelBookingApp.Domain.DomainModels;

namespace SMHotelBookingApp.Application.Dtos;

public class BookingDto 
{
    public int Id { get; set; }
    public Guid BookingReference { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Room Room { get; set; }

    public static Booking DtoToDomain(BookingDto dto)
    {
        return new Booking
        {
            BookingReference = dto.BookingReference,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            IsActive = dto.IsActive,
            Customer = dto.Customer,
            Room = dto.Room
        };
    }
}
