namespace PetFamily.Application
{
    public record CreateVolunteerCommand(string fullName,
                                         string email,
                                         string description,
                                         string phoneNumber);

    public class VolunteersService
    {
        public async Task Create(CreateVolunteerCommand command)
        {

        }
    }
}
