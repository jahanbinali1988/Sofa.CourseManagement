using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.PostQuestions.Commands
{
	public class DeletePostQuestionCommand : CommandBase
	{
		public DeletePostQuestionCommand(string instituteId, string fieldId, string courseId, string sessionId, string lessonplanId, string postId, string questionId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			SessionId = sessionId;
			LessonplanId = lessonplanId;
			PostId = postId;
			QuestionId = questionId;
		}

		public string InstituteId { get; }
		public string FieldId { get; }
		public string CourseId { get; }
		public string SessionId { get; }
		public string LessonplanId { get; }
		public string PostId { get; }
		public string QuestionId { get; }
	}
}
