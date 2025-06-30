namespace HairMakerCRM.Core.BargainItems;

public record BargainItem(
    Guid Id, 
    string Name, 
    decimal Price,
    int SessionDurationMinutes);
