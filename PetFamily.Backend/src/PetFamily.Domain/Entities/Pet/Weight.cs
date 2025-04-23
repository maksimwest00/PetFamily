using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class Weight : ComparableValueObject
    {
        public const int MAX_WEIGHT = 1000;

        private Weight(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<Weight, Error> Create(string value)
        {
            if (value.Length > MAX_WEIGHT)
                return Errors.General.ValueIsInvalid("Weight");

            var result = new Weight(value);

            return result;
        }
    }
}
