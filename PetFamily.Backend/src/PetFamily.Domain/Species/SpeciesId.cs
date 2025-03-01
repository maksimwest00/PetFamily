﻿using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species
{
    public class SpeciesId : ComparableValueObject
    {
        private SpeciesId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());

        public static SpeciesId Empty() => new(Guid.Empty);

        public static SpeciesId Create(Guid id) => new(id);

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}
