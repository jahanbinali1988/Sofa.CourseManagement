using Sofa.CourseManagement.Domain.LessonPlans.Exceptions;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Shared.ValueObjects
{
	public class CorelationId : ValueObject
	{

		public static implicit operator CorelationId(Guid? value)
		{
			return new CorelationId(value: value!);
		}

		private CorelationId() : base()
		{
		}

		public CorelationId(Guid? value) : this()
		{
			Validate(value);
			Value = value.ToString();
		}

		public void Validate(Guid? value)
		{
			if (value != null || value.Value == default)
				throw new InvalidCorelationIdValueException(value!.Value.ToString());
		}

		public string Value { get; set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value!;
		}
	}
}
