using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.Entities.Sessions;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Posts
{
	public abstract class PostBase : Entity<Guid>
	{
		public Title Title { get; private set; }
		public OrderNumber Order { get; private set; }
		public Content Content { get; private set; }
		public ContentType ContentType { get; private set; }

		public Guid LessonPlanId { get; private set; }
		public LessonPlan LessonPlan { get; private set; }

		public Guid? QuestionId { get; private set; }
		public PostQuestion? Question { get; private set; }

		protected PostBase() : base()
		{

		}

		protected void AssignContent(string content) { Content = content; }
		protected void AssignOrder(short order) { Order = order; }
		protected void AssignTitle(string title) { Title = title; }
		protected void AssignContentType(ContentTypeEnum contentType) { ContentType = contentType; }
		protected void AssignLessonPlan(Guid lessonPlanId) { LessonPlanId = lessonPlanId; }
		protected void AssignQuestion(Guid questionId) { QuestionId = questionId; }

		public abstract void Update(string title, string content, ContentTypeEnum contentType, short order);
		public abstract void Delete();
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
