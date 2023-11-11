namespace Domain.Entities.Contracts;

public abstract class PersonalDataEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime DateOfBirth { get; set; }

    protected PersonalDataEntity()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
    }

    protected PersonalDataEntity(
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }

    public void UpdatePersonalData(
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }
}
