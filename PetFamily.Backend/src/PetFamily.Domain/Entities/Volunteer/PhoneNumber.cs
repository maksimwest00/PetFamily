using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class PhoneNumber : ComparableValueObject
    {
        public const int MAX_LENGTH = 2900;

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<PhoneNumber, Error> Create(string value)
        {
            // TODO Валидация номера по Regex?

            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MAX_LENGTH)
                return Errors.General.ValueIsInvalid("PhoneNumber");

            var result = new PhoneNumber(value);

            return result;
        }
    }
}
