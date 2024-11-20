using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class DeleteImagePostDomainEvent : DomainEventBase
	{
		public DeleteImagePostDomainEvent() : base()
		{

		}
		public DeleteImagePostDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
