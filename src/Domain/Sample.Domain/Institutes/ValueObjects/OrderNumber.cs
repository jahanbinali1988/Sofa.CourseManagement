using Sofa.SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class OrderNumber : ValueObject
	{

		public static implicit operator OrderNumber(short value)
		{
			return new OrderNumber(value: value!);
		}

		private OrderNumber() : base()
		{
		}

		public OrderNumber(short value) : this()
		{
			Validate(value);
			Value = value;
		}

		public void Validate(short value)
		{
		}

		public short Value { get; private set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value!;
		}
	}
}
