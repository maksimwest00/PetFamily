namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerRequest(string FullName,
                                         string Email,
                                         string Description,
                                         string PhoneNumber,
                                         string ExpirienceYear);

}
