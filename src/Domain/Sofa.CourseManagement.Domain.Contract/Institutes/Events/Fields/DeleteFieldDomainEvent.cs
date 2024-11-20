using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields
{
	public class DeleteFieldDomainEvent : DomainEventBase
	{
		public DeleteFieldDomainEvent() : base()
		{

		}
		public DeleteFieldDomainEvent(Guid id) : this()
		{
			Id = id;
		}

		public Guid Id { get; set; }
	}
}
