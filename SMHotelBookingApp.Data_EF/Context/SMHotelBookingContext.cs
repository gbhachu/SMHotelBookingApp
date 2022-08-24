using Microsoft.EntityFrameworkCore;
using SMHotelBookingApp.Domain.DomainModels;

namespace SMHotelBookingApp.Data_EF.Context;

public class SMHotelBookingContext : DbContext
{
    public SMHotelBookingContext(DbContextOptions<SMHotelBookingContext> options)
        : base(options)
    {
    }

    public DbSet<Booking> Booking { get; set; }

    public DbSet<Room> Room { get; set; }

    public DbSet<Customer> Customer { get; set; }
}
