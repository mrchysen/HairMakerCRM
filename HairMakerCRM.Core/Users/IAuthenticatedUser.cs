namespace HairMakerCRM.Core.Users;

public interface IAuthenticatedUser
{
    Customer GetCustomer();

    void UpdateKey(string key, string value);
}

public static class AuthenticatedUserConstants
{
    public const string Name = "Name";

    public const string Surname = "Surname";

    public const string FatherName = "FatherName";

    public const string Phone = "Phone";

    public const string Email = "Email";
}