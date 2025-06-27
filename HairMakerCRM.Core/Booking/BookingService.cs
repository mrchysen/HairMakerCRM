namespace HairMakerCRM.Core.Booking;

public interface IBookingService
{
    public BookingItem CreateBook();
}

public class BookingService : IBookingService
{


    public BookingItem CreateBook()
    {
        throw new NotImplementedException();
    }
}
