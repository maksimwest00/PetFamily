using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class PetDetalis : ComparableValueObject
    {
        private readonly List<BankDetalis> _bankDetalis = [];

        public IReadOnlyList<BankDetalis> BankDetalis => _bankDetalis;

        public void AddBankDetalis(BankDetalis bankDetalis)
        {
            _bankDetalis.Add(bankDetalis);
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            foreach (var bankDetalis in _bankDetalis)
            {
                yield return bankDetalis;
            }
        }
    }
}
