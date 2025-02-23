using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Posts
{
	public class VideoPost : PostBase
	{
		public VideoPost() : base()
		{

		}
		public static VideoPost CreateInstance(Guid id, string title, short order, string content, Guid LessonPlanId)
		{
			var post = new VideoPost();

			post.AssignId(id);
			post.AssignTitle(title);
			post.AssignOrder(order);
			post.AssignContent(content);
			post.AssignLessonPlan(LessonPlanId);

			post.AddDomainEvent(new AddVideoPostDomainEvent(post.Id, post.Title.Value, post.Order.Value, post.Content.Value, post.ContentType.Value, post.LessonPlanId));

			return post;
		}

		public override void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteVideoPostDomainEvent(Id));
		}

		public override void Update(string title, string content, ContentTypeEnum contentType, short order)
		{
			AssignTitle(title);
			AssignContent(content);
			AssignContentType(contentType);
			AssignOrder(order);
			MarkAsUpdated();

			AddDomainEvent(new UpdateVideoPostDomainEvent(Id, Title.Value, Order.Value, Content.Value, ContentType.Value, LessonPlanId));
		}
	}
}
