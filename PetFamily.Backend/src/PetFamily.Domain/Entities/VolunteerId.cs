namespace PetFamily.Domain.Entities
{
    // ДЗ Черновик

    //public abstract record BaseId<T> where T : IIdentifiable, new()
    //{
    //    protected BaseId() 
    //    { 
    //    }
    //    public static T NewId() => new() { Value = Guid.NewGuid() };
    //    public static T Empty() => new() { Value = Guid.NewGuid() };
    //}

    //public interface IIdentifiable
    //{
    //    Guid Value { get; init; }
    //}

    //public record PersonID : BaseId<PersonID>, IIdentifiable
    //{
    //    public Guid Value { get; init; }
    //}

    public record VolunteerId
    {
        private VolunteerId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());

        public static VolunteerId Empty() => new(Guid.Empty);
    }
}
