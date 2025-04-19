using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Entities
{
    public class SpeciesAndBreed : ComparableValueObject
    {
        // ef core
        private SpeciesAndBreed()
        {

        }
        
        private SpeciesAndBreed(SpeciesId specieId, BreedId breedId)
        {
            SpecieId = specieId;
            BreedId = breedId;
        }

        public SpeciesId SpecieId { get; private set; }
        public BreedId BreedId { get; private set; }
        
        public static Result<SpeciesAndBreed, Error> Create(SpeciesId specieId, BreedId breedId)
        {
            if (specieId is null)
                return Errors.General.ValueIsInvalid("SpecieId");
            if (breedId is null)
                return Errors.General.ValueIsInvalid("BreedId");

            var speciesAndBreed = new SpeciesAndBreed(specieId, breedId);

            return (speciesAndBreed);
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return SpecieId;
            yield return BreedId;

        }
    }
}
