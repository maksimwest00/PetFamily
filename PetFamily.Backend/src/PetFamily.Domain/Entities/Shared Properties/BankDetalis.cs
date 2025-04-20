using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class BankDetalis : ComparableValueObject
    {
        // ef core
        private BankDetalis()
        {

        }

        private BankDetalis(string name,
                            string description,
                            string howDoTransfer)
        {
            Name = name;
            Description = description;
            HowDoTransfer = howDoTransfer;
        }

        public string Name { get; } = default!;
        
        public string Description { get; } = default!;
        
        public string HowDoTransfer { get; } = default!;

        public static Result<BankDetalis, Error> Create(string name,
                                                 string description,
                                                 string howDoTransfer)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsInvalid("Name");
            if (string.IsNullOrWhiteSpace(description))
                return Errors.General.ValueIsInvalid("Description");
            if (string.IsNullOrWhiteSpace(howDoTransfer))
                return Errors.General.ValueIsInvalid("HowDoTransfer");

            var bankDetalis = new BankDetalis(name,
                                              description,
                                              howDoTransfer);

            return (bankDetalis);
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Name;
            yield return Description;
            yield return HowDoTransfer;
        }
    }
}
