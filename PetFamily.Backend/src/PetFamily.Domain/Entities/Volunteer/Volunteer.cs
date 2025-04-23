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
                          FullName fullName,
                          Email email,
                          Description description,
                          PhoneNumber phoneNumber,
                          ExperienceYear experienceYear) : base(id)
        {
            FullName = fullName;
            Email = email;
            Description = description;
            PhoneNumber = phoneNumber;
            ExperienceYear = experienceYear;
        }

        public FullName FullName { get; private set; } = default!;

        public Email Email { get; private set; } = default!;

        public Description Description { get; private set; } = default!;

        public ExperienceYear ExperienceYear { get; private set; } = default!;

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

        public PhoneNumber PhoneNumber { get; private set; } = default!;

        public VolunteerDetalis? VolunteerDetalis { get; private set; }

        public void AddSocialNetwork(SocialNetwork socialNetwork)
        {
            VolunteerDetalis?.AddSocialNetwork(socialNetwork);
        }

        public IReadOnlyList<Pet> Pets => _pets;

        public static Result<Volunteer, Error> Create(VolunteerId id,
                                                      FullName fullName,
                                                      Email email,
                                                      Description description,
                                                      PhoneNumber phoneNumber,
                                                      ExperienceYear experienceYear)
        {
            var volunter = new Volunteer(id,
                                         fullName,
                                         email,
                                         description,
                                         phoneNumber,
                                         experienceYear);

            return volunter;
        }
    }
}
