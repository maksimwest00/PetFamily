using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Entities
{
    public class Pet : Entity
    {
        // ef core
        private Pet()
        {

        }
        private Pet(string nickName,
                    string description,
                    string color,
                    string infoAboutHealthPet,
                    string addressLocatePet)
        {
            Nickname = nickName;
            Description = description;
            Color = color;
            InfoAboutHealthPet = infoAboutHealthPet;
            AddressLocatePet = addressLocatePet;


            var speciesBreedIdsResult = SpeciesBreedRef.Create(Species.Id, Breed.Id);

            SpeciesBreedIds = speciesBreedIdsResult.Value;
        }

        public Guid Id { get; private set; }

        public string Nickname { get; private set; }

        public Species.Species Species { get; private set; }

        public string Description { get; private set; }

        public Breed Breed { get; private set; }

        public string Color { get; private set; }

        public string InfoAboutHealthPet { get; private set; }

        public string AddressLocatePet { get; private set; }

        public int Weight { get; private set; }

        public int Height { get; private set; }

        public int NumberPhone { get; private set; }

        public bool IsCostrate { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public bool IsVaccinated { get; private set; }

        public EStatusHelp StatusHelp { get; private set; }

        public ValueObject<BankDetalis> BankingData { get; private set; }

        public DateTime DateCreate { get; private set; }

        public ValueObject<SpeciesBreedRef> SpeciesBreedIds { get; private set; }

        public static Result<Pet> Create(string nickName,
                                         string description,
                                         string color,
                                         string infoAboutHealthPet,
                                         string AddressLocatePet)
        {
            if (string.IsNullOrWhiteSpace(nickName))
                return Result.Failure<Pet>("Nickname cannot be empty");

            var pet = new Pet(nickName, description, color, infoAboutHealthPet, AddressLocatePet);
            return Result.Success(pet);
        }
    }
}
