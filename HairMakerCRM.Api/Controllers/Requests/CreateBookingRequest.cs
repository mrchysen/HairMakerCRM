using HairMakerCRM.Core;

namespace HairMakerCRM.Api.Controllers.Requests;

public record CreateBookingRequest(
    DateTime StartTime, 
    List<BargainItem> BargainItems, 
    Master ChosenMaster);