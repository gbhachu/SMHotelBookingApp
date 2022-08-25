using SMHotelBookingApp.Data_EF.Context;
using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;

namespace SMHotelBookingApp.Data_EF.TypeRepository;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(SMHotelBookingContext context) : base(context)
    {
    }
}

