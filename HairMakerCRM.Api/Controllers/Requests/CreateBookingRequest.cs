namespace HairMakerCRM.Api.Controllers.Requests;

public record CreateBookingRequest(
    DateTime StartTime, 
    List<string> BargainItemIds, 
    string ChosenMasterId);