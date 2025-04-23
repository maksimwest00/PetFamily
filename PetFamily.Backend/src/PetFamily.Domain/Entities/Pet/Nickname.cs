using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class Nickname : ComparableValueObject
    {
        public const int MAX_LENGTH = 100;

        private Nickname(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<Nickname, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MAX_LENGTH)
                return Errors.General.ValueIsInvalid("Nickname");

            var result = new Nickname(value);

            return result;
        }
    }
}
