namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerRequest(string LastName,
                                         string FirstName,
                                         string MiddleName,
                                         string Email,
                                         string Description,
                                         string PhoneNumber,
                                         string ExpirienceYear);

}
