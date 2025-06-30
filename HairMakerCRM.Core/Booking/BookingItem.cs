using HairMakerCRM.Core.BargainItems;
using HairMakerCRM.Core.Masters;

namespace HairMakerCRM.Core.Booking;

public record BookingItem(
    Guid Id, 
    List<BargainItem> BargainItems, 
    Customer Customer,
    Master Master,
    string Description,
    DateTime StartTime,
    DateTime EndTime,
    BookingStatus BookingStatus = BookingStatus.WaitForApprove);

public enum BookingStatus
{
    WaitForApprove,
    Approved,
    Canceled
}
