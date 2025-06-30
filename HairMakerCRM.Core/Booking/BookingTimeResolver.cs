using HairMakerCRM.Core.BargainItems;
using HairMakerCRM.Core.Masters;

namespace HairMakerCRM.Core.Booking;

public interface IBookingTimeResolver
{
    Task<TimeResolveResult> Resolve(
        List<BargainItem> bargainItems,
        Master master,
        DateTime startTime);
}

public record TimeResolveResult(DateTime Start, DateTime End);

public class BookingTimeResolver(
    IBookingRepository bookingRepository) : IBookingTimeResolver
{
    public async Task<TimeResolveResult> Resolve(
        List<BargainItem> bargainItems,
        Master master,
        DateTime startTime)
    {
        var sumDuration = GetSumDuration(bargainItems);

        var endTime = startTime.Add(sumDuration);

        var existentBookingItems = await bookingRepository
            .GetByDateRangeAndMaster(DateTime.Now, endTime, master);

        foreach (var timeSpanItem in existentBookingItems)
        {
            if (timeSpanItem.EndTime >= startTime &&
                endTime >= timeSpanItem.StartTime)
            {
                throw new TimeBusyException(
                    $"Невозможно зарезервировать время с {startTime:dd.MM.yyyy с HH:mm} до {startTime:HH:mm}");
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
