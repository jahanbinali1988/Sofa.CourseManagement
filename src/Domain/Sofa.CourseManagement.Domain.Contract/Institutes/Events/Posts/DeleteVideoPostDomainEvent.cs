using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class DeleteVideoPostDomainEvent : DomainEventBase
	{
		public DeleteVideoPostDomainEvent() : base()
		{

		}
		public DeleteVideoPostDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
