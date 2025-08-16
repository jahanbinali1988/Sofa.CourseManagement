using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans
{
    public class AddLessonPlanDomainEvent : DomainEventBase
	{
		public AddLessonPlanDomainEvent() : base()
		{

		}
		public AddLessonPlanDomainEvent(Guid id, string title, Guid sessionId, Guid courseLanguageId, Guid courseId, Guid fieldId, Guid instituteId) : this()
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
		public Guid CourseLanguageId { get; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
