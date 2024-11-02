using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.Entities;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class CreatePostViewModel : ViewModelBase
	{
		public ContentTypeEnum ContentType { get; set; }
		public dynamic Post { get; set; }

		internal AddPostCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId, 
			Guid lessonplanId)
		{
			return new AddPostCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId,
				LessonPlanId = lessonplanId,
				Post = Post,
				ContentType = ContentType,
				SessionId = sessionId
			};
		}

		internal UpdatePostCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId, 
			Guid lessonplanId, Guid postId)
		{
			return new UpdatePostCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId,
				SessionId = sessionId,
				LessonPlanId = lessonplanId,
				Id = postId,
				Post = Post,
				ContentType = ContentType,
			};
		}

	}
}
