using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Session : Entity<Guid>
    {
        public Title Title { get; private set; }
		public OccurredDate OccurredDate { get; private set; }

		public Guid TermId { get; private set; }
        public Guid LessonPlanId { get; private set; }

        private Session()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignTerm(Guid termId) { this.TermId = termId; }
        public void AssignLessonPlan(Guid lessonPlanId) { this.LessonPlanId = lessonPlanId; }
		public void AssignOccurredDate(DateTimeOffset occurredDate) { this.OccurredDate = occurredDate; }

		public static Session CreateInstance(Guid id, string title, Guid lessonPlanId, Guid termId, DateTimeOffset occurredDate)
        {
            var session = new Session();

            session.AssignId(id);
            session.AssignTitle(title);
            session.AssignLessonPlan(lessonPlanId);
            session.AssignTerm(termId);
            session.AssignOccurredDate(occurredDate);

            return session;
        }
    }
}
