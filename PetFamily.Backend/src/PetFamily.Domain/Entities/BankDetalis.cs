using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public record BankDetalis
    {
        private BankDetalis(string name,
                            string description,
                            object howDoTransfer)
        {
            Name = name;
            Description = description;
            HowDoTransfer = howDoTransfer;
        }

        public string Name { get; } = default!;
        
        public string Description { get; } = default!;
        
        public object HowDoTransfer { get; } = default!;

        public static Result<BankDetalis> Create(string name,
                                                 string description,
                                                 object howDoTransfer)
        {
            // Какая-либо валидация name, description, howDoTransfer
            // н-р в случае не успеха Result.Failure("error")

            var bankDetalis = new BankDetalis(name, description, howDoTransfer);

            return Result.Success<BankDetalis>(bankDetalis);
        }
    }
}
