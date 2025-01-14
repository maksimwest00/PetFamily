using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class SpeciesBreedRef : ValueObject<SpeciesBreedRef>
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

        protected override bool EqualsCore(SpeciesBreedRef other)
        {
            return other.SpeciesId == SpeciesId && other.BreedId == BreedId;
        }

        protected override int GetHashCodeCore()
        {
            return GetHashCode();
        }

        public static Result<ValueObject<SpeciesBreedRef>> Create(Guid speciesId,
                                                                  Guid breedId)
        {
            // Какая-либо валидация GuId
            // н-р в случае не успеха Result.Failure("error")

            var spbreddRef = new SpeciesBreedRef(speciesId, breedId);

            return Result.Success<ValueObject<SpeciesBreedRef>>(spbreddRef);
        }
    }
}
