using HairMakerCRM.Core.Users;
using System.Diagnostics.Metrics;

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
    IBookingTimeResolver timeResolver) : IBookingService
{
    public Task<BookingItem?> CreateBooking(
        DateTime StartTime,
        List<BargainItem> BargainItems,
        Master ChosenMaster)
    {
        var timing = timeResolver.Resolve(
            BargainItems, 
            ChosenMaster, 
            StartTime);

        var newBooking = new BookingItem(
        Guid.NewGuid(),
        bargainItems,
            authenticatedUser.GetCustomer(),
            master,
            String.Empty,
            startTime,
            endTime,
            BookingStatus.WaitForApprove);

        await bookingRepository.Add(newBooking);

    }
}
