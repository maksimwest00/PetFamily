﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Entities
{
    public class Email : ComparableValueObject
    {
        public const int MAX_LENGTH = 100;

        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; } = default!;

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public static Result<Email, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MAX_LENGTH)
                return Errors.General.ValueIsInvalid("Email");

            var result = new Email(value);

            return result;
        }
    }
}
