using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class BankDetalis : ValueObject<BankDetalis>
    {
        public string Name { get; } = default!;
        
        public string Description { get; } = default!;
        
        public object HowDoTransfer { get; } = default!;

        protected override bool EqualsCore(BankDetalis other)
        {
            return Name == other.Name && Description == other.Description;
        }

        protected override int GetHashCodeCore()
        {
            return GetHashCode();
        }
    }
}
