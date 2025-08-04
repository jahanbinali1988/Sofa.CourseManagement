using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Users.ValueObjects
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

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
    }
}
