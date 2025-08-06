using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseLanguages
{
	public class DeleteCourseLanguageDomainEvent : DomainEventBase
	{
		public DeleteCourseLanguageDomainEvent()
		{
			
		}
		public DeleteCourseLanguageDomainEvent(Guid id, Guid courseId, Guid fieldId, Guid instituteId)
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
