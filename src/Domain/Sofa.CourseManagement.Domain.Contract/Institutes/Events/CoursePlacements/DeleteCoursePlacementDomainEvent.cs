using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacements
{
	public class DeleteCoursePlacementDomainEvent : DomainEventBase
	{
		public DeleteCoursePlacementDomainEvent() : base()
		{
			
		}
		public DeleteCoursePlacementDomainEvent(Guid id, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
