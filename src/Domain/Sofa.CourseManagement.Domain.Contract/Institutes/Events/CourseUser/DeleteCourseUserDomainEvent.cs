using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser
{
	public class DeleteCourseUserDomainEvent : DomainEventBase
	{
		public DeleteCourseUserDomainEvent()
		{
			
		}
		public DeleteCourseUserDomainEvent(Guid id, Guid fieldId, Guid instituteId) : this(id)
		{
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
