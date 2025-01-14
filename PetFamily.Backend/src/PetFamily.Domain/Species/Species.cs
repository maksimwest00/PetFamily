using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species
{
    public class Species
    {
        private readonly List<Breed> _breeds = [];

        // ef core
        private Species()
        {

        }

        private Species(string name)
        {
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IReadOnlyList<Breed> Breeds => _breeds;

        public Result<Breed> AddBreed(Breed breed)
        {
            _breeds.Add(breed);
            return Result.Success(breed);
        }

        public static Result<Species> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Species>("name cannot be empty");

            var species = new Species(name);

            return Result.Success(species);
        }
    }
}
