using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Users.ValueObjects
{
	public class PhoneNumber : ValueObject
    {
        public static implicit operator PhoneNumber(string value)
        {
            return new PhoneNumber(value: value!);
        }

        private PhoneNumber() : base()
        {
        }

        public PhoneNumber(string value) : this()
        {
            Validate(value);
            Value = value;
        }

        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringPhoneNumberLength)
                throw new InvalidPhoneNumberValueException(value);
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
    }
}
