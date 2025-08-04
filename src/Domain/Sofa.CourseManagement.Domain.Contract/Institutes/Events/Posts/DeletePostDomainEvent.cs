using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class DeletePostDomainEvent : DomainEventBase
	{
		public DeletePostDomainEvent() : base()
		{

		}
		public DeletePostDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
