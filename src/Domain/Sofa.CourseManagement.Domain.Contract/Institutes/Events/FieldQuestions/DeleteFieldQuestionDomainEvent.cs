using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestions
{
	public class DeleteFieldQuestionDomainEvent : DomainEventBase
	{
		public DeleteFieldQuestionDomainEvent() : base()
		{
			
		}
		public DeleteFieldQuestionDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
