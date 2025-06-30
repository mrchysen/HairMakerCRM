using HairMakerCRM.Core.BargainItems;
using HairMakerCRM.Core.Masters;
using HairMakerCRM.Core.Users;

namespace HairMakerCRM.Core.Booking;

public interface IBookingService
{
    public Task<BookingItem> CreateBooking(
        DateTime startTime,
        List<string> bargainItemIds,
        string chosenMasterId);
}

public class BookingService(
    IBookingRepository bookingRepository,
    IBookingTimeResolver timeResolver,
    IAuthenticatedUser authenticatedUser,
    IMasterRepository masterRepository,
    IBargainItemRepository bargainItemRepository) : IBookingService
{
    public async Task<BookingItem> CreateBooking(
        DateTime startTime,
        List<string> bargainItemIds,
        string chosenMasterId)
    {
        var master = await masterRepository.GetMasterById(chosenMasterId);

        var bargainItems = await bargainItemRepository.GetBargainItemsByIds(bargainItemIds);

        var timing = await timeResolver.Resolve(
            bargainItems,
            master,
            startTime);

        var newBooking = new BookingItem(
        Guid.NewGuid(),
        bargainItems,
            authenticatedUser.GetCustomer(),
            master,
            String.Empty,
            timing.Start,
            timing.End,
            BookingStatus.WaitForApprove);

        await bookingRepository.Add(newBooking);

        return newBooking;
    }
}
