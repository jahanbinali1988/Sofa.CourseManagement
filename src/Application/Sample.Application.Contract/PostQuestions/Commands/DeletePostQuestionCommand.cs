using Sofa.CourseManagement.Application.Contract.Shared;
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

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id SessionId { get; }
		public Id LessonplanId { get; }
		public Id PostId { get; }
		public Id QuestionId { get; }
	}
}
