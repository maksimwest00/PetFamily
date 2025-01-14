using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class SocialNetwork
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

        public static Result<SocialNetwork> Create(string link, string name)
        {
            if (string.IsNullOrWhiteSpace(link))
                return Result.Failure<SocialNetwork>("link cannot be empty");
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<SocialNetwork>("name cannot be empty");

            var socialNetwork = new SocialNetwork(link, name);
            return Result.Success(socialNetwork);
        }
    }
}
