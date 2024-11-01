using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
    public class OccurredDate : ValueObject
    {

        public static implicit operator OccurredDate(DateTimeOffset value)
        {
            return new OccurredDate(value: value);
        }

        private OccurredDate() : base()
        {
        }

        public OccurredDate(DateTimeOffset value) : this()
        {
            Validate(value);
            Value = value;
        }

        public void Validate(DateTimeOffset value)
        {
            if (value <= DateTimeOffset.Now)
                throw new InvalidOccurredDateValueException(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }

        public DateTimeOffset? Value { get; private set; }
    }
}
