using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestionChoices
{
	public class DeleteFieldQuestionChoiceDomainEvent : DomainEventBase
	{
		public DeleteFieldQuestionChoiceDomainEvent() : base()
		{

		}
		public DeleteFieldQuestionChoiceDomainEvent(Guid id) : this()
		{
			this.Id = id;
		}
		public Guid Id { get; set; }
	}
}
