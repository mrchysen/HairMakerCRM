namespace HairMakerCRM.Core.Booking;

public class TimeBusyException : Exception
{
    public TimeBusyException(string message) : base(message) { }
}
