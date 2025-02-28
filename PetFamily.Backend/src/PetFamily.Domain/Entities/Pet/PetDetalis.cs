namespace PetFamily.Domain.Entities
{
    public record PetDetalis
    {
        private readonly List<BankDetalis> _bankDetalis = [];

        public IReadOnlyList<BankDetalis> BankDetalis => _bankDetalis;

        public void AddBankDetalis(BankDetalis bankDetalis)
        {
            _bankDetalis.Add(bankDetalis);
        }
    }
}
