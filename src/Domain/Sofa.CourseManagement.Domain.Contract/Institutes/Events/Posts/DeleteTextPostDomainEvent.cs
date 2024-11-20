using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class DeleteTextPostDomainEvent : DomainEventBase
	{
		public DeleteTextPostDomainEvent() : base()
		{

		}
		public DeleteTextPostDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
    }
}
