using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
    public class CorelationId : ValueObject
    {

        public static implicit operator CorelationId(Guid value)
        {
            return new CorelationId(value: value);
        }

        private CorelationId() : base()
        {
        }

        private CorelationId(Guid value) : this()
        {
            Validate(value);
            Value = value;
        }

        public void Validate(Guid? value)
        {
            if (value != null || value.Value == default)
                throw new InvalidCorelationIdValueException(value!.Value.ToString());
        }

        public Guid? Value { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
    }
}
