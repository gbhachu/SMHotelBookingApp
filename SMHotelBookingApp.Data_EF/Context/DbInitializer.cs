using SMHotelBookingApp.Data_EF.Interfaces;
using SMHotelBookingApp.Domain.DomainModels;
using System;
namespace SMHotelBookingApp.Data_EF.Context;

public class DbInitializer : IDbInitializer
{
    // This method will create and seed the database.
    public void Initialize(SMHotelBookingContext context)
    {
        // Delete the database, if it already exists. I do this because an
        // existing database may not be compatible with the entity model,
        // if the entity model was changed since the database was created.
        context.Database.EnsureDeleted();

        // Create the database, if it does not already exists. This operation
        // is necessary, if you dont't use the in-memory database.
        context.Database.EnsureCreated();

        // Look for any bookings.
        if (context.Booking.Any())
        {
            return;   // DB has been seeded
        }

        List<Customer> customers = new()
        {
            new Customer { Name="Gurminder Bhachu", Email="gb@test.com" },
            new Customer { Name="Vicki Young", Email="vy@test.com" }
        };

        List<Room> rooms = new()
        {
            new Room { Description="Standard" },
            new Room { Description="Double" },
            new Room { Description="Delux" }
        };

        DateTime date = DateTime.Today.AddDays(4);

        

        List<Booking> bookings = new()
        {
            new Booking { StartDate=date, EndDate=date.AddDays(14), IsActive=true, CustomerId=1 , RoomId=1 },
            new Booking { StartDate=date, EndDate=date.AddDays(14), IsActive=true, CustomerId=2, RoomId=2 },
            new Booking { StartDate=date, EndDate=date.AddDays(14), IsActive=true, CustomerId=1, RoomId=3 }
        };

        context.Customer.AddRange(customers);
        context.Room.AddRange(rooms);
        context.SaveChanges();
        context.Booking.AddRange(bookings);
        context.SaveChanges();
    }
}
