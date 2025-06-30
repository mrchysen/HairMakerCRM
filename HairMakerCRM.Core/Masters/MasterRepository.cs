namespace HairMakerCRM.Core.Masters;

public interface IMasterRepository
{
    Task<Master> GetMasterById(string id);
}

public class MasterRepository
{

}
