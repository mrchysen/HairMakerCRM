namespace HairMakerCRM.Core.Booking.Models;

public class BookingParams
{
    public bool ShowOldBookings { get; set; }

    public int BatchSize { get; set; }

    public Guid? ShowByMasterId { get; set; }

    public DateTime? DateTimeFrom { get; set; }

    public DateTime? DateTimeTo { get; set; }

    public bool IsMaster { get; set; }

    public Guid? CustomerId { get; set; }
}