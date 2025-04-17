using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;

namespace Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos
{
	public class FieldQuestionDto : EntityBaseDto
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public LevelEnum Level { get; set; }
		public QuestionType Type { get; set; }
	}
}
