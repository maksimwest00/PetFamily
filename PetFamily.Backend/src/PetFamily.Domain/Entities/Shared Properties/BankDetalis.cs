using CSharpFunctionalExtensions;

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

        public static Result<BankDetalis> Create(string name,
                                                 string description,
                                                 string howDoTransfer)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<BankDetalis>("name cannot be empty");
            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<BankDetalis>("description cannot be empty"); ;
            if (string.IsNullOrWhiteSpace(howDoTransfer))
                return Result.Failure<BankDetalis>("howDoTransfer cannot be empty"); ;

            var bankDetalis = new BankDetalis(name, description, howDoTransfer);

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
