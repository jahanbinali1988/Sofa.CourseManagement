using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser
{
	public class UpdateCourseUserDomainEvent : DomainEventBase
	{
		public UpdateCourseUserDomainEvent()
		{
			
		}
		public UpdateCourseUserDomainEvent(Guid id, Guid courseId, Guid userId, Guid fieldId, Guid instituteId)
		{
			Id = id;
			CourseId = courseId;
			UserId = userId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid CourseId { get; set; }
		public Guid UserId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
