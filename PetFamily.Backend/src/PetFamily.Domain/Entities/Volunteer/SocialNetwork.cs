using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class SocialNetwork : ComparableValueObject
    {
        // ef core
        private SocialNetwork()
        {

        }

        public SocialNetwork(string link, string name)
        {
            Link = link;
            Name = name;
        }

        public string Link { get; private set; } = default!;
        
        public string Name { get; private set; } = default!;

        public static Shared.Result<SocialNetwork> Create(string link, string name)
        {
            if (string.IsNullOrWhiteSpace(link))
                return ("link cannot be empty");
            if (string.IsNullOrWhiteSpace(name))
                return ("name cannot be empty");

            var socialNetwork = new SocialNetwork(link, name);
            return (socialNetwork);
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Link;
            yield return Name;
        }
    }
}
