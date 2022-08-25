using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;
using System.Linq.Expressions;

namespace SMHotelBookingApp.UnitTests.Moqs;

public class MoqRoomRepository : IGenericRepository<Room>
{
    public bool addWasCalled = false;
    public bool editWasCalled = false;
    public bool removeWasCalled = false;

    public void Add(Room entity)
    {
        addWasCalled = true;
    }

    public void Edit(Room entity)
    {
        editWasCalled = true;
    }

    public IEnumerable<Room> Find(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Room Get(int id)
    {
        return new Room { Id = 1, Description = "A" };
    }

    public IEnumerable<Room> GetAll()
    {
        List<Room> rooms = new()
        {
                new Room { Id=1, Description="Standard" },
                new Room { Id=2, Description="Double" },
            };
        return rooms;
    }

    public Room GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(Room entity)
    {
        removeWasCalled = true;
    }
}
