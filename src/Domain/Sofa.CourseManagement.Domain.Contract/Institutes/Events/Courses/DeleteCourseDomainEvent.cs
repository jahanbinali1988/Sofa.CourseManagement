using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses
{
	public class DeleteCourseDomainEvent : DomainEventBase
	{
		public DeleteCourseDomainEvent() : base() { }
		public DeleteCourseDomainEvent(Guid id, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
