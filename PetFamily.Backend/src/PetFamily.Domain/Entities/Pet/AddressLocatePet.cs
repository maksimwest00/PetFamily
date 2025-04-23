using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class AddressLocatePet : ComparableValueObject
    {
        public const int MAX_LENGTH = 100;

        private AddressLocatePet(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<AddressLocatePet, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MAX_LENGTH)
                return Errors.General.ValueIsInvalid("AddressLocatePet");

            var result = new AddressLocatePet(value);

            return result;
        }
    }
}
