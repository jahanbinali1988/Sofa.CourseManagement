using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class QuestionType : BusinessTypeValueObject<QuestionTypeEnum>
	{
		public static implicit operator QuestionType(QuestionTypeEnum value)
		{
			return new QuestionType(value);
		}

		private QuestionType() : base()
		{
		}

		public QuestionType
			(QuestionTypeEnum ageRangeEnum) : base(value: ageRangeEnum)
		{
		}
	}
}
