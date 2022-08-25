using SMHotelBookingApp.Domain.DomainModels;

namespace SMHotelBookingApp.Application.Dtos
{
    public static class DtoToDomain
    {
        public static Booking BookingDtoToDomain(BookingDto dto)
        {
            return new Booking
            {
                BookingReference = dto.BookingReference,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = dto.IsActive,
                Customer = dto.Customer,
                Room = dto.Room
            };
        }
    }
}
