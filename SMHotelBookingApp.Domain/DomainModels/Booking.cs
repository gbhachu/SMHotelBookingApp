using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMHotelBookingApp.Domain.DomainModels;

[Table("Booking")]
public class Booking
{
    [Key]
    public int Id { get; set; }
    [Required]
    public Guid BookingReference { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }
    [Required]
    public virtual Customer Customer { get; set; }
    [Required]
    public virtual Room Room { get; set; }

    
}
