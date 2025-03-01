using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class PetId : ComparableValueObject
    {
        private PetId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static PetId NewMyPetId() => new(Guid.NewGuid());

        public static PetId Empty() => new(Guid.Empty);

        public static PetId Create(Guid id) => new(id);

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}
