using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class InfoAboutHealthPet : ComparableValueObject
    {
        public const int MAX_LENGTH = 100;

        private InfoAboutHealthPet(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<InfoAboutHealthPet, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MAX_LENGTH)
                return Errors.General.ValueIsInvalid("InfoAboutHealthPet");

            var result = new InfoAboutHealthPet(value);

            return result;
        }
    }
}
