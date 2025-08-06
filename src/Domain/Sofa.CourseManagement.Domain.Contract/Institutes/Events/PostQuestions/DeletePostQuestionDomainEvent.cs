using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.PostQuestions
{
	public class DeletePostQuestionDomainEvent : DomainEventBase
	{
		public DeletePostQuestionDomainEvent() : base()
		{
			
		}
		public DeletePostQuestionDomainEvent(Guid id, Guid postId, Guid lessonPlanId, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			PostId = postId;
			LessonPlanId = lessonPlanId;
			SessionId = sessionId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public Guid PostId { get; set; }
		public Guid LessonPlanId { get; set; }
		public Guid SessionId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
