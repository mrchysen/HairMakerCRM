namespace HairMakerCRM.Core.BargainItems;

public interface IBargainItemRepository
{
    Task<List<BargainItem>> GetBargainItemsByIds(List<string> ids);
}

public class BargainItemRepository
{
}
