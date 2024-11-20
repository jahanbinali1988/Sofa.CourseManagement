using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts
{
	public class DeleteSoundPostDomainEvent : DomainEventBase
	{
		public DeleteSoundPostDomainEvent() : base()
		{

		}
		public DeleteSoundPostDomainEvent(Guid id) : this()
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
