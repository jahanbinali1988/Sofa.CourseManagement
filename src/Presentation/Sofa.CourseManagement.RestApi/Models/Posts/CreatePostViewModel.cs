using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class CreatePostViewModel : ViewModelBase
	{
		public ContentTypeEnum ContentType { get; set; }
		public dynamic Post { get; set; }

		internal AddPostCommand ToCommand(string instituteId, string fieldId, string courseId, string sessionId, 
			string lessonplanId)
		{
			return new AddPostCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				LessonPlanId = lessonplanId,
				Post = Post,
				ContentType = ContentType,
				SessionId = sessionId
			};
		}

		internal UpdatePostCommand ToCommand(string instituteId, string fieldId, string courseId, string sessionId, 
			string lessonplanId, string postId)
		{
			return new UpdatePostCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				SessionId = sessionId,
				LessonPlanId = lessonplanId,
				Id = postId,
				Post = Post,
				ContentType = ContentType,
			};
		}

	}
}
