using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.Domain.Shared.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Session : Entity<Guid>
    {
        public Title Title { get; private set; }

        public CorelationId TermId { get; private set; }
        public Term Term { get; private set; }
        public CorelationId LessonPlanId { get; private set; }
        public LessonPlan LessonPlan { get; private set; }

        private Session()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignTerm(Guid termId) { this.TermId = termId; }
        public void AssignTerm(Term term) { this.TermId = term.Id; this.Term = term; }
        public void AssignLessonPlan(Guid lessonPlanId) { this.LessonPlanId = lessonPlanId; }
        public void AssignLessonPlan(LessonPlan lessonPlan) { this.LessonPlanId = lessonPlan.Id; this.LessonPlan = lessonPlan; }

        public static Session CreateInstance(Guid id, string title, Guid lessonPlanId, Guid termId, bool isActive, string description)
        {
            var session = new Session();

            session.AssignId(id);
            session.AssignTitle(title);
            session.AssignLessonPlan(lessonPlanId);
            session.AssignTerm(termId);

            return session;
        }
    }
}
