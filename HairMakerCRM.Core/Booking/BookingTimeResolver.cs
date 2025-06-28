using HairMakerCRM.Core.Users;

namespace HairMakerCRM.Core.Booking;

internal interface IBookingTimeResolver
{
    public TimeResolveResult? Resolve(
        List<BargainItem> bargainItems, 
        Master master,
        DateTime startTime);
}

internal record TimeResolveResult(DateTime start, DateTime end);

internal class BookingTimeResolver(
    IBookingRepository bookingRepository,
    IAuthenticatedUser authenticatedUser) : IBookingTimeResolver
{
    public async Task<TimeResolveResult?> Resolve(
        List<BargainItem> bargainItems, 
        Master master,
        DateTime startTime)
    {
        var sumDuration = GetSumDuration(bargainItems);

        var endTime = startTime.Add(sumDuration);

        var existentBookingItems = await bookingRepository.GetByDateRangeAndMaster(DateTime.Now, endTime, master);

        foreach(var item in existentBookingItems)
        {
            if(item.EndTime >= startTime && 
                endTime >= item.StartTime)
            {
                return null;
            }
        }

        
        return newBooking;
    }

    private TimeSpan GetSumDuration(List<BargainItem> bargainItems)
    {
        var totalMinutes = bargainItems.Sum(c => c.SessionDurationMinutes);

        return new TimeSpan(0, totalMinutes, 0);
    }
}
