﻿using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Entities
{
    public class VolunteerId : ComparableValueObject
    {
        private VolunteerId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());

        public static VolunteerId Empty() => new(Guid.Empty);

        public static VolunteerId Create(Guid id) => new(id);

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}
