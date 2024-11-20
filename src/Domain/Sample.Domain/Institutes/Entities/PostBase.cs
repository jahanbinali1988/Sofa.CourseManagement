using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public abstract class PostBase : Entity<Guid>
    {
        public Title Title { get; private set; }
        public short Order { get; private set; }
        public Content Content { get; private set; }
        public ContentType ContentType { get; private set; }
        public Guid LessonPlanId { get; private set; }
        protected PostBase() : base()
        {

        }

        protected void AssignContent(string content) { Content = content; }
        protected void AssignOrder(short order) { Order = order; }
        protected void AssignTitle(string title) { Title = title; }
        protected void AssignContentType(ContentTypeEnum contentType) { ContentType = contentType; }
        protected void AssignLessonPlan(Guid lessonPlanId) { LessonPlanId = lessonPlanId; }

        public abstract void Update(string title, string content, ContentTypeEnum contentType, short order);
		public abstract void Delete();
	}
}
