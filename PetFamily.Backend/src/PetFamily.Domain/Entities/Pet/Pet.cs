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

        public Pet(PetId id,
                   Nickname nickName,
                   Description description,
                   Color color,
                   InfoAboutHealthPet infoAboutHealthPet,
                   AddressLocatePet addressLocatePet,
                   Weight weight,
                   Height height,
                   PhoneNumber phoneNumber,
                   bool isCastrated,
                   DateOfBirth dateOfBirth,
                   bool isVaccinated,
                   StatusHelp statusHelp) : base(id)
        {
            Nickname = nickName;
            Description = description;
            Color = color;
            InfoAboutHealthPet = infoAboutHealthPet;
            AddressLocatePet = addressLocatePet;
            Weight = weight;
            Height = height;
            PhoneNumber = phoneNumber;
            IsCastrated = isCastrated;
            DateOfBirth = dateOfBirth;
            IsVaccinated = isVaccinated;
            StatusHelp = statusHelp;
            DateCreate = DateTime.Now;
        }

        public Nickname Nickname { get; private set; } = default!;

        public Description Description { get; private set; } = default!;

        public Color Color { get; private set; } = default!;

        public InfoAboutHealthPet InfoAboutHealthPet { get; private set; } = default!;

        public AddressLocatePet AddressLocatePet { get; private set; } = default!;

        public Weight Weight { get; private set; } = default!;

        public Height Height { get; private set; } = default!;

        public PhoneNumber PhoneNumber { get; private set; } = default!;

        public bool IsCastrated { get; private set; }

        public DateOfBirth DateOfBirth { get; private set; }

        public bool IsVaccinated { get; private set; }

        public StatusHelp StatusHelp { get; private set; }

        public PetDetalis? PetDetalis { get; private set; }

        public DateTime DateCreate { get; private set; }
        
        public SpeciesAndBreed? SpeciesAndBreed { get; private set; }
        

    }
}
