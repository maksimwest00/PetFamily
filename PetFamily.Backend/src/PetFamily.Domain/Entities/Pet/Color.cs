using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class Color : ComparableValueObject
    {
        public const int MAX_LENGTH = 100;

        private Color(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<Color, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MAX_LENGTH)
                return Errors.General.ValueIsInvalid("Color");

            var result = new Color(value);

            return result;
        }
    }
}
