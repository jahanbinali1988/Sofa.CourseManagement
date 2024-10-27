using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.LessonPlans.ValueObjects;
using Sofa.CourseManagement.Domain.Shared.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.LessonPlans.Entities
{
    public class PostBase : Entity<Guid>
    {
        public Title Title { get; private set; }
        public short Order { get; private set; }
        public Content Content { get; private set; }
		public ContentType ContentType { get; private set; }

		public CorelationId LessonPlanId { get; private set; }
        public LessonPlan LessonPlan { get; private set; }

        protected PostBase()
        {

        }

        protected void AssignContent(string content) { Content = content; }
        protected void AssignOrder(short order) { Order = order; }
        protected void AssignTitle(string title) { Title = title; }
		protected void AssignContentType(ContentTypeEnum contentType) { ContentType = contentType; }
		protected void AssignLessonPlan(Guid lessonPlanId) { LessonPlanId = lessonPlanId; }
        protected void AssignLessonPlan(LessonPlan lessonPlan) { LessonPlanId = lessonPlan.Id; LessonPlan = lessonPlan; }

    }
}
