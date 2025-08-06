using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class DeletePostDomainEvent : DomainEventBase
	{
		public DeletePostDomainEvent() : base()
		{

		}
		public DeletePostDomainEvent(Guid id, Guid lessonPlanId, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			LessonPlanId = lessonPlanId;
			SessionId = sessionId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public Guid LessonPlanId { get; set; }
		public Guid SessionId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
