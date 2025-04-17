using MediatR;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Commands;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class CreatePostQuestionViewModel : ViewModelBase
	{
		public PriorityEnum Priority { get; set; }
		public string QuestionId { get; set; }
		public string QuestionTitle { get; set; }
		public string PostTitle { get; set; }

		internal CreatePostQuestionCommand ToCommand(string instituteId, string fieldId, string courseId, string sessionId, string lessonplanId, string postId)
		{
			return new CreatePostQuestionCommand(instituteId, fieldId, courseId, sessionId, lessonplanId, postId, Priority, QuestionId, QuestionTitle, PostTitle);
		}
	}
}
