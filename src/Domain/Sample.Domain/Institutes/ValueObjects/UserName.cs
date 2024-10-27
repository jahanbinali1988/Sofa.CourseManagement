using Sofa.CourseManagement.Domain.Institutes.Constants;
using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
    public class UserName : ValueObject
    {
        public static implicit operator UserName(string value)
        {
            return new UserName(value: value!);
        }

        private UserName() : base()
        {
        }

        public UserName(string value) : this()
        {
            Validate(value);
            Value = value;
        }

        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringUserNameLength)
                throw new InvalidUserNameValueException(value);
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
    }
}
