using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class FullName : ComparableValueObject
    {
        public const int MAX_LENGTH = 100;

        public string LastName { get; }
        public string FirstName { get; }
        public string MiddleName { get; }

        public FullName(
            string lastName,               
            string firstName,    
            string middleName)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }

        //private FullName(string value)
        //{
        //    Value = value;
        //}

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<FullName, Error> Create(
            string lastName,
            string firstName,
            string middleName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                return Errors.General.ValueIsInvalid("LastName");

            if (string.IsNullOrWhiteSpace(firstName))
                return Errors.General.ValueIsInvalid("FirstName");

            if (string.IsNullOrWhiteSpace(middleName))
                return Errors.General.ValueIsInvalid("MiddleName");

            if (string.Format("{0} {1} {2}", lastName, firstName, middleName).Length > MAX_LENGTH)
                return Errors.General.ValueIsInvalid("FullName");

            var result = new FullName(lastName,
                                      firstName,
                                      middleName);

            return result;
        }
    }
}
