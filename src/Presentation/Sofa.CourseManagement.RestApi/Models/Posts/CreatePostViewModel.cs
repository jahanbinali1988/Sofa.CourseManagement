using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class CreatePostViewModel : ViewModelBase
	{
		public ContentTypeEnum ContentType { get; set; }
		public dynamic Post { get; set; }

		internal AddPostCommand ToCommand(Guid lessonpalnId)
		{
			return new AddPostCommand()
			{
				Post = Post,
				ContentType = ContentType,
				LessonPlanId = lessonpalnId
			};
		}

		internal UpdatePostCommand ToCommand(Guid lessonpalnId, Guid id)
		{
			return new UpdatePostCommand()
			{
				Id = id,
				Post = Post,
				ContentType = ContentType,
				LessonPlanId = lessonpalnId
			};
		}

	}
}
