using SMHotelBookingApp.Domain.DomainModels;

namespace SMHotelBookingApp.Application.Dtos;

public class BookingDto 
{
    public int Id { get; set; }
    public Guid BookingReference { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Room Room { get; set; }

    
}
