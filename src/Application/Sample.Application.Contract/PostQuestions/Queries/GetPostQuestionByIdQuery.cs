using Sofa.CourseManagement.Application.Contract.PostQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.PostQuestions.Queries
{
	public class GetPostQuestionByIdQuery : GetByIdQueryBase, IQuery<PostQuestionDto>
	{
		public GetPostQuestionByIdQuery(string instituteId, string fieldId, string courseId, string sessionId, string lessonplanId, string postId, string questionId) : base(questionId)
		{
			FieldId = fieldId;
			CourseId = courseId;
			SessionId = sessionId;
			LessonplanId = lessonplanId;
			PostId = postId;
			InstituteId = instituteId;
		}

		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id SessionId { get; }
		public Id LessonplanId { get; }
		public Id PostId { get; }
		public Id InstituteId { get; }
	}
}
