namespace HairMakerCRM.Core.Booking.Models;

public class TimeBusyException : Exception
{
    public TimeBusyException(string message) : base(message) { }
}
