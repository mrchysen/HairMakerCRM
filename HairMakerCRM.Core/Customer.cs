namespace HairMakerCRM.Core;

public record Customer(
    Guid Id, 
    string Name,
    string Surname,
    string? FatherName,
    int Age,
    Gender Gender = Gender.None);

public enum Gender
{
    Male,
    Female,
    None
}
