using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Users.ValueObjects
{
	public class Name : ValueObject
    {
        public static implicit operator Name(string value)
        {
            return new Name(value: value!);
        }

        private Name() : base()
        {
        }

        public Name(string value) : this()
        {
            Validate(value);
            Value = value;
        }

        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringNameLength)
                throw new InvalidNameValueException(value);
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
    }
}
