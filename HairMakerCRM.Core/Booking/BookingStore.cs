using HairMakerCRM.Core.Booking.Models;

namespace HairMakerCRM.Core.Booking;

public interface IBookingStore
{
    Task<BookingItem?> GetBookingItemById(Guid bookingId);

    Task<List<BookingItem>> GetBookingItemsByParams(BookingParams @params);
}

public class BookingStore(IBookingRepository repository) : IBookingStore
{
    public async Task<BookingItem?> GetBookingItemById(Guid bookingId)
    {
        // TODO: Check permissions
        // Customers can see only their booking
        // Master can see all

        return await repository.GetById(bookingId);
    }

    public Task<List<BookingItem>> GetBookingItemsByParams(BookingParams @params)
    {
        // TODO: Check permissions
        // Customers can see only their booking
        // Master can see all

        throw new NotImplementedException();
    }
}
