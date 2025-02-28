using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Entities
{
    public record SpeciesAndBreed
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
        
        public static Result<SpeciesAndBreed> Create(SpeciesId specieId, BreedId breedId)
        {
            if (specieId is null)
                return ("specieId cannot be empty");
            if (breedId is null)
                return ("breedId cannot be empty");
            
            var speciesAndBreed = new SpeciesAndBreed(specieId, breedId);

            return (speciesAndBreed);
        }
    }
}
