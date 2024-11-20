using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class Title : ValueObject
    {

        public static implicit operator Title(string value)
        {
            return new Title(value: value!);
        }

        private Title() : base()
        {
        }

        public Title(string value) : this()
        {
            Validate(value);
            Value = value;
        }

        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringTitleLength)
                throw new InvalidTitleValueException(value);
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
    }
}
