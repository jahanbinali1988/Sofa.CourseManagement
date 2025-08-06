using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacements
{
	public class UpdateCoursePlacementDomainEvent : DomainEventBase
	{
		public UpdateCoursePlacementDomainEvent() : base()
		{
			
		}
		public UpdateCoursePlacementDomainEvent(Guid id, string title, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			Title = title;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public string Title { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
