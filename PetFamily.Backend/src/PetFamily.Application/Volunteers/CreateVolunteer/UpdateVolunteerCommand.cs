namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerDto(string fullName,
                                     string email,
                                     string description,
                                     string phoneNumber);

    public record CreateVolunteerDtoResponse(string response);

}
