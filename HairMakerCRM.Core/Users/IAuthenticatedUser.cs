namespace HairMakerCRM.Core.Users;

public interface IAuthenticatedUser
{
    Guid GetId();
    
    Customer GetCustomer();

    string? GetValueByKey(string key);

    void UpdateKey(string key, string value);

    bool IsMaster { get; }
}

public static class AuthenticatedUserConstants
{
    public const string Id = "Id";

    public const string Name = "Name";

    public const string Surname = "Surname";

    public const string FatherName = "FatherName";

    public const string Phone = "Phone";

    public const string Email = "Email";

    public const string MasterFlag = "MasterFlag";
}