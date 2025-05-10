using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class CreatePostViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public short Order { get; set; }

		internal AddPostCommand ToCommand(string instituteId, string fieldId, string courseId, string sessionId, 
			string lessonplanId)
		{
			return new AddPostCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				LessonPlanId = lessonplanId,
				SessionId = sessionId,
				ContentType = this.ContentType,
				Title = this.Title,
				Content = this.Content,
				Order = this.Order
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
				ContentType = this.ContentType,
				Title = this.Title,
				Content = this.Content,
				Order = this.Order
			};
		}

	}
}
