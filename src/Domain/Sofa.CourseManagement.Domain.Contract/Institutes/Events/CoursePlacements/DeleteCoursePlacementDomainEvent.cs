using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacements
{
	public class DeleteCoursePlacementDomainEvent : DomainEventBase
	{
		public DeleteCoursePlacementDomainEvent() : base()
		{
			
		}
		public DeleteCoursePlacementDomainEvent(Guid id) : this()
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}
