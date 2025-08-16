using Sofa.CourseManagement.Application.Contract.PostQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.PostQuestions.Commands
{
	public class AddPostQuestionCommand : CommandBase<PostQuestionDto>
	{
		public AddPostQuestionCommand(string instituteId, string fieldId, string courseId, string sessionId, string lessonplanId, 
			string postId, PriorityEnum priority, string questionId, string questionTitle, string postTitle)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			SessionId = sessionId;
			LessonplanId = lessonplanId;
			PostId = postId;
			Priority = priority;
			QuestionId = questionId;
			QuestionTitle = questionTitle;
			PostTitle = postTitle;
		}

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id SessionId { get; }
		public Id LessonplanId { get; }
		public Id PostId { get; }
		public PriorityEnum Priority { get; }
		public Id QuestionId { get; }
		public string QuestionTitle { get; }
		public string PostTitle { get; }
	}
}
