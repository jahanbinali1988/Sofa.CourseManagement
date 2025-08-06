using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.PostQuestions
{
	public class UpdatePostQuestionDomainEvent : DomainEventBase
	{
		public UpdatePostQuestionDomainEvent() : base()
		{
			
		}
		public UpdatePostQuestionDomainEvent(Guid id, PriorityEnum priority, Guid questionId, Guid postId, Guid lessonPlanId, Guid sessionId, Guid courseId, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			Priority = priority;
			QuestionId = questionId;
			PostId = postId;
			LessonPlanId = lessonPlanId;
			SessionId = sessionId;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public PriorityEnum Priority { get; set; }
		public Guid QuestionId { get; set; }
		public Guid PostId { get; set; }
		public Guid LessonPlanId { get; set; }
		public Guid SessionId { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
