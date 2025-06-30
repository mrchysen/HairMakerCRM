namespace HairMakerCRM.Core.Booking;

public interface IBookingCanceler
{
    Task Cancel(string bookingItemId);
}

public class BookingCanceler(IBookingRepository bookingRepository) : IBookingCanceler
{
    public async Task Cancel(string bookingItemId)
    {
        if(Guid.TryParse(bookingItemId, out var id))
            throw new ArgumentException($"{nameof(bookingItemId)} должен быть валидным id");

        await bookingRepository.UpdateStatus(id, BookingStatus.Canceled);
    }
}
