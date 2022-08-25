using SMHotelBookingApp.Data_EF.Context;
using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;

namespace SMHotelBookingApp.Data_EF.TypeRepository;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    public RoomRepository(SMHotelBookingContext sMHotelBookingContex) : base(sMHotelBookingContex)
    {
    }
}
