using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions;
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
        public Guid? LessonPlanId { get; private set; }

		public LessonPlan? LessonPlan { get; private set; }

		private Session() : base()
        {

        }

        private void AssignTitle(string title) { this.Title = title; }
        private void AssignTermId(Guid termId) { this.TermId = termId; }
        private void AssignLessonPlanId(Guid lessonPlanId) { this.LessonPlanId = lessonPlanId; }
		private void AssignLessonPlan(LessonPlan lessonPlan) { this.LessonPlan = lessonPlan; }
		private void AssignOccurredDate(DateTimeOffset occurredDate) { this.OccurredDate = occurredDate; }

		public static Session CreateInstance(Guid id, string title, Guid termId, DateTimeOffset occurredDate)
        {
            var session = new Session();

            session.AssignId(id);
            session.AssignTitle(title);
            session.AssignTermId(termId);
            session.AssignOccurredDate(occurredDate);

            session.AddDomainEvent(new AddSessionDomainEvent(session.Id, session.Title.Value, session.OccurredDate.Value, session.TermId));

            return session;
        }
		public void Update(string title, DateTimeOffset occurredDate)
		{
            AssignTitle(title);
			AssignOccurredDate(occurredDate);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateSessionDomainEvent(Id, Title.Value, OccurredDate.Value, TermId));
		}
		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteSessionDomainEvent(Id));
		}
		public void AddLessonPlan(LessonPlan lessonplan)
		{
			AssignLessonPlanId(lessonplan.Id);
			AssignLessonPlan(lessonplan);
		}
		public void DeleteLessonPlan(LessonPlan lessonplan)
		{
            LessonPlan = null;
		}
	}
}
