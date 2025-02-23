using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.PostQuestions
{
	public class DeletePostQuestionDomainEvent : DomainEventBase
	{
		public DeletePostQuestionDomainEvent() : base()
		{
			
		}
		public DeletePostQuestionDomainEvent(Guid id) : this()
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}
