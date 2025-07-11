using HairMakerCRM.Core.Booking.Models;

namespace HairMakerCRM.Core.Booking;

public interface ICancelingBookingService
{
    Task Cancel(string bookingItemId);
}

public class CancelingBookingService(IBookingRepository bookingRepository) : ICancelingBookingService
{
    public async Task Cancel(string bookingItemId)
    {   // Сделать так чтобы мог снимать запись либо мастер, либо сам покупатель
        if(Guid.TryParse(bookingItemId, out var id))
            throw new ArgumentException($"{nameof(bookingItemId)} должен быть валидным id");

        await bookingRepository.UpdateStatus(id, BookingStatus.Canceled);
    }
}
