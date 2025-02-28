namespace PetFamily.Domain.Entities
{
    public record VolunteerDetalis
    {
        private readonly List<SocialNetwork> _socialNetworks = [];
        private readonly List<BankDetalis> _bankDetalis = [];

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
        public IReadOnlyList<BankDetalis> BankDetalis => _bankDetalis;

        public void AddSocialNetwork(SocialNetwork socialNetwork)
        {
            _socialNetworks.Add(socialNetwork);
        }

        public void AddBankDetalis(BankDetalis bankDetalis)
        {
            _bankDetalis.Add(bankDetalis);
        }
    }
}
