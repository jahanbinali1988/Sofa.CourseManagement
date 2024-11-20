using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms
{
	public class DeleteTermDomainEvent : DomainEventBase
	{
		public DeleteTermDomainEvent() : base()
		{

		}
		public DeleteTermDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
