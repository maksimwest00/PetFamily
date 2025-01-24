using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public record SpeciesBreedRef
    {
        public Guid SpeciesId { get; }
        public Guid BreedId { get; }

        // ef core
        private SpeciesBreedRef()
        {

        }

        private SpeciesBreedRef(Guid speciesId, Guid breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }
        public static Result<SpeciesBreedRef> Create(Guid speciesId,
                                                                  Guid breedId)
        {
            // Какая-либо валидация GuId
            // н-р в случае не успеха Result.Failure("error")

            var spbreddRef = new SpeciesBreedRef(speciesId, breedId);

            return Result.Success<SpeciesBreedRef>(spbreddRef);
        }
    }
}
