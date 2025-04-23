using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class DateOfBirth : ComparableValueObject
    {
        public const int MAX_YEAR = 100;

        private DateOfBirth(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<DateOfBirth, Error> Create(DateTime value)
        {
            if (value > DateTime.Now)
                return Errors.General.ValueIsInvalid("DateOfBirth");

            var result = new DateOfBirth(value);

            return result;
        }
    }
}
