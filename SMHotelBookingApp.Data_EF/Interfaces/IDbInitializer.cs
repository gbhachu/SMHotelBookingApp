using SMHotelBookingApp.Data_EF.Context;

namespace SMHotelBookingApp.Data_EF.Interfaces;

public interface IDbInitializer
{
    void Initialize(SMHotelBookingContext context);
}
