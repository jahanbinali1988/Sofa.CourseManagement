using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.Constants;
using Sofa.CourseManagement.Domain.Institutes.Exceptions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class Code : ValueObject
	{
		public static implicit operator Code(string? value)
		{
			return new Code(value: value!);
		}

		private Code() : base()
		{
		}

		public Code(string? value) : this()
		{
			Validate(value);
			Value = value;
		}

		public void Validate(string? value)
		{
			if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringCodeLength)
				throw new InvalidCodeValueException(value);
		}

		public string? Value { get; private set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value!;
		}
	}
}
