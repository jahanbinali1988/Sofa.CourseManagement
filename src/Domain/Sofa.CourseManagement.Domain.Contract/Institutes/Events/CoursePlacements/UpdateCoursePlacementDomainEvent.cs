using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacements
{
	public class UpdateCoursePlacementDomainEvent : DomainEventBase
	{
		public UpdateCoursePlacementDomainEvent() : base()
		{
			
		}
		public UpdateCoursePlacementDomainEvent(Guid id, string title, Guid courseId) : this()
		{
			Id = id;
			Title = title;
			CourseId = courseId;
		}

		public Guid Id { get; }
		public string Title { get; }
		public Guid CourseId { get; }
	}
}
