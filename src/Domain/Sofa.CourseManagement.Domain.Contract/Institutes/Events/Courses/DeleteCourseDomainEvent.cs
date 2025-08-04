using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses
{
	public class DeleteCourseDomainEvent : DomainEventBase
	{
		public DeleteCourseDomainEvent() : base() { }
		public DeleteCourseDomainEvent(Guid id) : this()
		{
			Id = id;
		}

		public Guid Id { get; set; }
	}
}
