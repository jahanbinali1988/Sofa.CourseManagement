using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans
{
	public class DeleteLessonPlanDomainEvent : DomainEventBase
	{
        public DeleteLessonPlanDomainEvent() : base()
        {
        }
        public DeleteLessonPlanDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
