using SMHotelBookingApp.Data_EF.Context;
using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;

namespace SMHotelBookingApp.Data_EF.TypeRepository;
public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(SMHotelBookingContext context) : base(context)
    {
    }
}
