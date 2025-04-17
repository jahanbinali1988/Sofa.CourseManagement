using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.Application.Contract.PostQuestions.Dtos
{
	public class PostQuestionDto : EntityBaseDto
	{
		public PriorityEnum Priority { get; set; }
		public Id QuestionId { get; set; }
		public string QuestionTitle { get; set; }
		public Id PostId { get; set; }
		public string PostTitle { get; set; }
	}
}
