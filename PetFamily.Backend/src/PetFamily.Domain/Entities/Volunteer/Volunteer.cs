using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public sealed class Volunteer : Shared.Entity<VolunteerId>
    {
        
        private readonly List<Pet> _pets = [];


        // ef core
        private Volunteer(VolunteerId id) : base(id)
        {

        }

        private Volunteer(VolunteerId id,
                          string fullName,
                          string email,
                          string description,
                          string phoneNumber) : base(id)
        {
            FullName = fullName;
            Email = email;
            Description = description;
            PhoneNumber = phoneNumber;
        }

        public string FullName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int ExperienceYear { get; private set; }

        public int CountAnimalsWhichCouldFindHome()
        {
            return Pets.Where(x => x.StatusHelp == EStatusHelp.FoundHome).Count();
        }

        public int CountAnimalsWhichFindingHomeNow()
        {
            return Pets.Where(x => x.StatusHelp == EStatusHelp.LookingHome).Count();
        }

        public int CountAnimalsWhichLocateOnTreatment()
        {
            return Pets.Where(x => x.StatusHelp == EStatusHelp.NeedHelp).Count();
        }

        public string PhoneNumber { get; set; } = default!;

        public VolunteerDetalis? VolunteerDetalis { get; private set; }

        public void AddSocialNetwork(SocialNetwork socialNetwork)
        {
            VolunteerDetalis.AddSocialNetwork(socialNetwork);
        }

        public IReadOnlyList<Pet> Pets => _pets;

        public static Result<Volunteer> Create(VolunteerId id,
                                               string fullName,
                                               string email,
                                               string description,
                                               string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return Result.Failure<Volunteer>("FullName cannot be empty");

            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Volunteer>("Email cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Volunteer>("Description cannot be empty");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return Result.Failure<Volunteer>("PhoneNumber cannot be empty");

            var volunter = new Volunteer(id, fullName, email, description, phoneNumber);

            return (volunter);
        }
    }
}
