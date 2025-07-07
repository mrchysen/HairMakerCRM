namespace HairMakerCRM.Api.Controllers.Requests;

public class GetBookingRequest
{
    public bool ShowOldBookings { get; set; } = false;

    public int BatchSize { get; set; } = 20;

    public Guid? ShowByMasterId { get; set; }

    public DateTime? DateTimeFrom { get; set; }

    public DateTime? DateTimeTo { get; set; }
}