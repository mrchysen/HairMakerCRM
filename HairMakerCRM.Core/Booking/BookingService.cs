using HairMakerCRM.Core.Users;

namespace HairMakerCRM.Core.Booking;

public interface IBookingService
{
    public Task<BookingItem?> CreateBooking(
        DateTime StartTime,
        List<BargainItem> BargainItems,
        Master ChosenMaster);
}

public class BookingService(
    IBookingRepository bookingRepository,
    IBookingTimeResolver timeResolver,
    IAuthenticatedUser authenticatedUser) : IBookingService
{
    public async Task<BookingItem?> CreateBooking(
        DateTime startTime,
        List<BargainItem> bargainItems,
        Master chosenMaster)
    {
        var timing = await timeResolver.Resolve(
            bargainItems,
            chosenMaster,
            startTime);

        if (timing is null)
            return null;

        var newBooking = new BookingItem(
        Guid.NewGuid(),
        bargainItems,
            authenticatedUser.GetCustomer(),
            chosenMaster,
            String.Empty,
            timing.Start,
            timing.End,
            BookingStatus.WaitForApprove);

        await bookingRepository.Add(newBooking);

        return newBooking;
    }
}
