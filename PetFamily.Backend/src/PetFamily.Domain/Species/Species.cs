using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species
{
    public class Species : Shared.Entity<SpeciesId>
    {
        private List<Breed> _breeds = [];

        // ef core
        private Species(SpeciesId id) : base(id)
        {

        }

        private Species(SpeciesId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IReadOnlyList<Breed> Breeds => _breeds;

        public static Result<Species> Create(SpeciesId id,
                                             string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return ("name cannot be empty");
            var specie = new Species(id);
            return (specie);
        }
    }
}
