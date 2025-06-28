namespace HairMakerCRM.Core.Booking;

public interface IBookingTimeResolver
{
    Task<TimeResolveResult?> Resolve(
        List<BargainItem> bargainItems,
        Master master,
        DateTime startTime);
}

public record TimeResolveResult(DateTime Start, DateTime End);

public class BookingTimeResolver(
    IBookingRepository bookingRepository) : IBookingTimeResolver
{
    public async Task<TimeResolveResult?> Resolve(
        List<BargainItem> bargainItems,
        Master master,
        DateTime startTime)
    {
        var sumDuration = GetSumDuration(bargainItems);

        var endTime = startTime.Add(sumDuration);

        var existentBookingItems = await bookingRepository
            .GetByDateRangeAndMaster(DateTime.Now, endTime, master);

        foreach (var item in existentBookingItems)
        {
            if (item.EndTime >= startTime &&
                endTime >= item.StartTime)
            {
                return null;
            }
        }

        return new(startTime, endTime);
    }

    private TimeSpan GetSumDuration(List<BargainItem> bargainItems)
    {
        var totalMinutes = bargainItems.Sum(c => c.SessionDurationMinutes);

        return new TimeSpan(0, totalMinutes, 0);
    }
}
