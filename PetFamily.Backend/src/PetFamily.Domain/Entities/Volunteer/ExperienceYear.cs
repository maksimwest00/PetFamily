using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class ExperienceYear : ComparableValueObject
    {
        public const int MAX_YEAR = 2000;

        private ExperienceYear(int value)
        {
            Value = value;
        }

        public int Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<ExperienceYear, Error> Create(string value)
        {
            if (!int.TryParse(value, out int expYear) && expYear > MAX_YEAR)
                return Errors.General.ValueIsInvalid("ExperienceYear");

            var result = new ExperienceYear(expYear);

            return result;
        }
    }
}
