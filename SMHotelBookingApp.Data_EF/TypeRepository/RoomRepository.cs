using SMHotelBookingApp.Data_EF.Context;
using SMHotelBookingApp.Domain.DomainModels;

namespace SMHotelBookingApp.Data_EF.TypeRepository;

public class RoomRepository : GenericRepository<Room>
{
    public RoomRepository(SMHotelBookingContext sMHotelBookingContex) : base(sMHotelBookingContex)
    {
    }
}
