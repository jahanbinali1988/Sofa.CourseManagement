using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Posts
{
	public class Post : Entity<Guid>
	{
		public Title Title { get; private set; }
		public OrderNumber Order { get; private set; }
		public Content Content { get; private set; }
		public ContentType ContentType { get; private set; }

		public Guid LessonPlanId { get; private set; }
		public LessonPlan LessonPlan { get; private set; }

		public Guid? QuestionId { get; private set; }
		public PostQuestion? Question { get; private set; }

		protected Post() : base()
		{

		}

		protected void AssignContent(string content) { Content = content; }
		protected void AssignOrder(short order) { Order = order; }
		protected void AssignTitle(string title) { Title = title; }
		protected void AssignContentType(ContentTypeEnum contentType) { ContentType = contentType; }
		protected void AssignLessonPlan(Guid lessonPlanId) { LessonPlanId = lessonPlanId; }
		protected void AssignQuestion(Guid questionId) { QuestionId = questionId; }

		public static Post CreateInstance(Guid id, string title, short order, string content, ContentTypeEnum contentTypeEnum, Guid lessonPlanId, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId)
		{
			var post = new Post();

			post.AssignId(id);
			post.AssignTitle(title);
			post.AssignOrder(order);
			post.AssignContent(content);
			post.AssignLessonPlan(lessonPlanId);
			post.AssignContentType(contentTypeEnum);

			post.AddDomainEvent(new AddPostDomainEvent(post.Id, post.Title.Value, post.Order.Value, post.Content.Value, post.ContentType.Value, lessonPlanId, sessionId, courseId, fieldId, instituteId));

			return post;
		}

		public void Delete(Guid lessonPlanId, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId)
		{
			MarkAsDeleted();
			AddDomainEvent(new DeletePostDomainEvent(Id, lessonPlanId, sessionId, courseId, fieldId, instituteId));
		}

		public void Update(string title, string content, ContentTypeEnum contentType, short order, Guid lessonPlanId, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId)
		{
			AssignTitle(title);
			AssignContent(content);
			AssignContentType(contentType);
			AssignOrder(order);
			MarkAsUpdated();

			AddDomainEvent(new UpdatePostDomainEvent(Id, Title.Value, Order.Value, Content.Value, ContentType.Value, lessonPlanId, sessionId, courseId, fieldId, instituteId));
		}

		public void AddQuestion(PostQuestion postQuestion)
		{
			Question = postQuestion;
			QuestionId = postQuestion.Id;
		}
		public void RemoveQuestion(PostQuestion postQuestion)
		{
			Question = null;
			QuestionId = null;
		}
	}
}
