using Sofa.CourseManagement.Application.Contract.Shared;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Dtos
{
	public class CoursePlacementQuestionDto : EntityBaseDto
	{
		public Id QuestionId { get; set; }
		public string QuestionTitle { get; set; }
		public int Order { get; set; }
	}
}
