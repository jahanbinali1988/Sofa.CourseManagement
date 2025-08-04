using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class AgeRange : BusinessTypeValueObject<AgeRangeEnum>
	{
		public static implicit operator AgeRange(AgeRangeEnum value)
		{
			return new AgeRange(value);
		}

		private AgeRange() : base()
		{
		}

		public AgeRange
			(AgeRangeEnum ageRangeEnum) : base(value: ageRangeEnum)
		{
		}
	}
}
