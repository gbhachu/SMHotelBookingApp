using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMHotelBookingApp.Domain.DomainModels;

[Table("Room")]
public class Room
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
}