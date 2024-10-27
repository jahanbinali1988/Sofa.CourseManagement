using Sofa.CourseManagement.Domain.Institutes.Constants;
using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
    public class Email : ValueObject
    {
        public static implicit operator Email(string value)
        {
            return new Email(value: value!);
        }

        private Email() : base()
        {
        }

        public Email(string value) : this()
        {
            Validate(value);
            Value = value;
        }

        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringEmailLength)
                throw new InvalidEmailValueException(value);
        }

        public string? Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
    }
}
