using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public sealed class Pet : Shared.Entity<PetId>
    {
        // ef core
        private Pet(PetId id) : base(id)
        {

        }

        private Pet(PetId id,
                    string nickName,
                    string description,
                    string color,
                    string infoAboutHealthPet,
                    string addressLocatePet) : base(id)
        {
            Nickname = nickName;
            Description = description;
            Color = color;
            InfoAboutHealthPet = infoAboutHealthPet;
            AddressLocatePet = addressLocatePet;
        }

        public string Nickname { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string Color { get; private set; } = default!;

        public string InfoAboutHealthPet { get; private set; } = default!;

        public string AddressLocatePet { get; private set; } = default!;

        public int Weight { get; private set; }

        public int Height { get; private set; }

        public string NumberPhone { get; private set; } = default!;

        public bool IsCostrate { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public bool IsVaccinated { get; private set; }

        public EStatusHelp StatusHelp { get; private set; }

        public PetDetalis? PetDetalis { get; private set; }

        public DateTime DateCreate { get; private set; }
        
        public SpeciesAndBreed? SpeciesAndBreed { get; private set; }
        
        public static Result<Pet, Error> Create(PetId petId,
                                         string nickName,
                                         string description,
                                         string color,
                                         string infoAboutHealthPet,
                                         string AddressLocatePet)
        {
            if (string.IsNullOrWhiteSpace(nickName))
                return Errors.General.ValueIsInvalid("Nickname");

            var pet = new Pet(petId, nickName, description, color, infoAboutHealthPet, AddressLocatePet);
            return pet;
        }
    }
}
