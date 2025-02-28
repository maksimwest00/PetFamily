using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public record BankDetalis
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
            // Какая-либо валидация name, description, howDoTransfer
            // н-р в случае не успеха Result.Failure("error")

            var bankDetalis = new BankDetalis(name, description, howDoTransfer);

            return (bankDetalis);
        }
    }
}
