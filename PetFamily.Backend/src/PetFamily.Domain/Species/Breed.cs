using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species
{
    public class Breed
    {
        // ef core
        private Breed()
        {

        }

        public Breed(string name)
        {
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;

        public static Result<Breed> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Breed>("name cannot be empty");

            var breed = new Breed(name);

            return Result.Success(breed);
        }
    }
}
