using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class Priority : BusinessTypeValueObject<PriorityEnum>
	{
		public static implicit operator Priority(PriorityEnum value)
		{
			return new Priority(value);
		}

		private Priority() : base()
		{
		}

		public Priority
			(PriorityEnum priority) : base(value: priority)
		{
		}
	}
	
}
