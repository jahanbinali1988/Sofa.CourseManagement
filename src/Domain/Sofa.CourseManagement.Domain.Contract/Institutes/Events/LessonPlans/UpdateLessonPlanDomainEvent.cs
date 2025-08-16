using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans
{
    public class UpdateLessonPlanDomainEvent : DomainEventBase
	{
        public UpdateLessonPlanDomainEvent() : base()
        {
            
        }
        public UpdateLessonPlanDomainEvent(Guid id, string title, Guid sessionId, Guid courseLanguageId, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			Title = title;
			SessionId = sessionId;
			CourseLanguageId = courseLanguageId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public string Title { get; set; }
		public Guid SessionId { get; set; }
		public Guid CourseLanguageId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
