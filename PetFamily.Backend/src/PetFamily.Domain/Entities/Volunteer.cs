using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class Volunteer : Entity
    {
        private readonly List<SocialNetwork> _socialNetworks = [];
        private readonly List<Pet> _pets = [];

        // ef core
        private Volunteer()
        {

        }

        private Volunteer(string fullName,
                          string email,
                          string description,
                          string phoneNumber)
        {
            FullName = fullName;
            Email = email;
            Description = description;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; }

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

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

        public void AddSocialNetwork(SocialNetwork socialNetwork)
        {
            _socialNetworks.Add(socialNetwork);
        }

        public ValueObject<BankDetalis> BankDetalis { get; private set; } = default!;

        public IReadOnlyList<Pet> Pets => _pets;

        public Result<Pet> AddPet(Pet pet)
        {
            _pets.Add(pet);
            return Result.Success(pet);
        }

        public static Result<Volunteer> Create(string fullName,
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

            var volunter = new Volunteer(fullName, email, description, phoneNumber);

            return Result.Success(volunter);
        }
    }
}
