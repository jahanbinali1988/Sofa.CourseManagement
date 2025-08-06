using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestionChoices
{
	public class DeleteFieldQuestionChoiceDomainEvent : DomainEventBase
	{
		public DeleteFieldQuestionChoiceDomainEvent() : base()
		{

		}
		public DeleteFieldQuestionChoiceDomainEvent(Guid id, Guid questionId, Guid fieldId, Guid instituteId) : this()
		{
			this.Id = id;
			QuestionId = questionId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public Guid QuestionId { get; }
		public Guid FieldId { get; }
		public Guid InstituteId { get; }
	}
}
