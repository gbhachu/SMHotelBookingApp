using SMHotelBookingApp.Data_EF.Context;
using SMHotelBookingApp.Data_EF.TypeRepository;
using SMHotelBookingApp.Domain.Interfaces;

namespace SMHotelBookingApp.Data_EF.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly SMHotelBookingContext _context;
    public UnitOfWork(SMHotelBookingContext context)
    {
        _context = context;
        Booking = new BookingRepository(_context);
        Customer = new CustomerRepository(_context);
        Room = new RoomRepository(_context);
    }
    public IBookingRepository Booking { get; private set; }

    public ICustomerRepository Customer { get; private set; }

    public IRoomRepository Room { get; private set; }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

}

