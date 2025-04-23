using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class Height : ComparableValueObject
    {
        public const int MAX_HEIGHT = 1000;

        private Height(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<Height, Error> Create(string value)
        {
            if (value.Length > MAX_HEIGHT)
                return Errors.General.ValueIsInvalid("Height");

            var result = new Height(value);

            return result;
        }
    }
}
