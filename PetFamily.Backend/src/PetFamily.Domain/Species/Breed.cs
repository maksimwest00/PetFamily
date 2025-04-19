using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species
{
    public class Breed : Shared.Entity<BreedId>
    {
        // ef core
        private Breed(BreedId id) : base(id) 
        { 

        }

        private Breed(BreedId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; } = default!;

        public static Result<Breed> Create(BreedId id,
                                           string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Breed>("name cannot be empty");

            var breed = new Breed(id, name);
            return (breed);
        }
    }
}
