using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestions
{
	public class DeleteFieldQuestionDomainEvent : DomainEventBase
	{
		public DeleteFieldQuestionDomainEvent() : base()
		{
			
		}
		public DeleteFieldQuestionDomainEvent(Guid id, Guid fieldId, Guid instituteId) : this()
		{
			Id = id;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Guid Id { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
