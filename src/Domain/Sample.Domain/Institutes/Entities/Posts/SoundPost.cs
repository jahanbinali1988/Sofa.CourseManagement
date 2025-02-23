using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Posts
{
	public class SoundPost : PostBase
	{
		public SoundPost() : base()
		{

		}
		public static SoundPost CreateInstance(Guid id, string title, short order, string content, Guid LessonPlanId)
		{
			var post = new SoundPost();

			post.AssignId(id);
			post.AssignTitle(title);
			post.AssignOrder(order);
			post.AssignContent(content);
			post.AssignLessonPlan(LessonPlanId);

			post.AddDomainEvent(new AddSoundPostDomainEvent(post.Id, post.Title.Value, post.Order.Value, post.Content.Value, post.ContentType.Value, post.LessonPlanId));

			return post;
		}

		public override void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteSoundPostDomainEvent(Id));
		}

		public override void Update(string title, string content, ContentTypeEnum contentType, short order)
		{
			AssignTitle(title);
			AssignContent(content);
			AssignContentType(contentType);
			AssignOrder(order);
			MarkAsUpdated();

			AddDomainEvent(new UpdateSoundPostDomainEvent(Id, Title.Value, Order.Value, Content.Value, ContentType.Value, LessonPlanId));
		}
	}
}
