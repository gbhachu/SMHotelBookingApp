using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;
using System.Linq.Expressions;

namespace SMHotelBookingApp.UnitTests.Moqs;

public class MoqBookingRepository : IGenericRepository<Booking>
{
    private DateTime fullyOccupiedStartDate;
    private DateTime fullyOccupiedEndDate;

    public MoqBookingRepository(DateTime start, DateTime end)
    {
        fullyOccupiedStartDate = start;
        fullyOccupiedEndDate = end;
    }

    public bool addWasCalled = false;
    public void Add(Booking entity)
    {
        addWasCalled = true;
    }

    public bool editWasCalled = false;
    public void Edit(Booking entity)
    {
        editWasCalled = true;
    }

    public IEnumerable<Booking> Find(Expression<Func<Booking, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Booking Get(int id)
    {
        return new Booking { Id = 1, StartDate = fullyOccupiedStartDate, EndDate = fullyOccupiedEndDate, IsActive = true, CustomerId = 1, RoomId = 1 };
    }

    public IEnumerable<Booking> GetAll()
    {
        List<Booking> bookings = new List<Booking>
            {
                new Booking { Id=1, StartDate=fullyOccupiedStartDate, EndDate=fullyOccupiedEndDate, IsActive=true, CustomerId=1, RoomId=1 },
                new Booking { Id=2, StartDate=fullyOccupiedStartDate, EndDate=fullyOccupiedEndDate, IsActive=true, CustomerId=2, RoomId=2 },
            };
        return bookings;
    }

    public Booking GetById(int id)
    {
        return new Booking { Id = 1, StartDate = fullyOccupiedStartDate, EndDate = fullyOccupiedEndDate, IsActive = true, CustomerId = 1, RoomId = 1 };
    }

    public bool removeWasCalled = false;
    public void Remove(Booking entity)
    {
        removeWasCalled = true;
    }

}
