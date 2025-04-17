using MediatR;
using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.Courses.Dtos;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CreateCoursePlacementQuestionViewModel : ViewModelBase
	{
		public string QuestionId { get; set; }
		public string QuestionTitle { get; set; }
		public int Order { get; set; }

		internal AddCoursePlacementQuestionCommand ToCommand(string instituteId, string fieldId, string courseId, string placementId)
		{
			return new AddCoursePlacementQuestionCommand(instituteId, fieldId, courseId, placementId, QuestionId, QuestionTitle, Order);
		}
	}
}
