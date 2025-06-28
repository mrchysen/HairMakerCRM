namespace HairMakerCRM.Core.Users;

public interface IAuthenticatedUser
{
    Customer GetCustomer();
}