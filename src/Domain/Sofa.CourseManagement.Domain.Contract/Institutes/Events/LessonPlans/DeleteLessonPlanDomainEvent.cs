using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans
{
	public class DeleteLessonPlanDomainEvent : DomainEventBase
	{
        public DeleteLessonPlanDomainEvent() : base()
        {
        }
        public DeleteLessonPlanDomainEvent(Guid id, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			SessionId = sessionId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public Guid SessionId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
