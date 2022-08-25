namespace SMHotelBookingApp.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBookingRepository Booking { get; }

    ICustomerRepository Customer { get; }

    IRoomRepository Room { get; }

    int Save();
}
