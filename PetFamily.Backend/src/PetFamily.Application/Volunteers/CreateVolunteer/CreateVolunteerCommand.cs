namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerCommand(string fullName,
                                         string email,
                                         string description,
                                         string phoneNumber);
}
