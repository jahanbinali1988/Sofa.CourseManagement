using Sofa.CourseManagement.Domain.LessonPlans.Constants;
using Sofa.CourseManagement.Domain.LessonPlans.Exceptions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.LessonPlans.ValueObjects
{
	public class Content : ValueObject
	{

		public static implicit operator Content(string? value)
		{
			return new Content(value: value!);
		}

		private Content() : base()
		{
		}

		public Content(string? value) : this()
		{
			Validate(value);
			Value = value;
		}

		public void Validate(string? value)
		{
			if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringContentLength)
				throw new InvalidContentValueException(value);
		}

		public string? Value { get; private set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value!;
		}
	}
}
