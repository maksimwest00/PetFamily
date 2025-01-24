namespace PetFamily.Domain.Entities
{
    public record PetId
    {
        private PetId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static PetId NewVolunteerId() => new(Guid.NewGuid());

        public static PetId Empty() => new(Guid.Empty);
    }
}
