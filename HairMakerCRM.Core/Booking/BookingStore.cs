using HairMakerCRM.Core.Booking.Models;
using HairMakerCRM.Core.Users;

namespace HairMakerCRM.Core.Booking;

/// <summary>
/// Хранилище для работы с записями.
/// Предоставляет методы для получения записей по ID или параметрам фильтрации.
/// Ожидается проверка прав доступа: клиенты видят только свои записи, мастера — все.
/// </summary>
public interface IBookingStore
{
    Task<BookingItem?> GetBookingItemById(Guid bookingId);

    Task<List<BookingItem>> GetBookingItemsByParams(BookingParams @params);
}

public class BookingStore(
    IBookingRepository repository,
    IAuthenticatedUser authenticatedUser) : IBookingStore
{
    public async Task<BookingItem?> GetBookingItemById(Guid bookingId)
    {
        // TODO: Check permissions
        // Customers can see only their booking
        // Master can see all

        var masterFlag = authenticatedUser.IsMaster;

        var booking = await repository.GetById(bookingId);

        if(booking is null)
            yield;

        if (masterFlag)
            return booking;

        if (!masterFlag && booking.Customer.Id == authenticatedUser.GetId())
            return booking;
        
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
