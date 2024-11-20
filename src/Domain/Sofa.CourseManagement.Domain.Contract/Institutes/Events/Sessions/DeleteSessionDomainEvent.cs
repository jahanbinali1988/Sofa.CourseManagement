using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions
{
	public class DeleteSessionDomainEvent : DomainEventBase
	{
        public DeleteSessionDomainEvent() : base()
        {
            
        }
        public DeleteSessionDomainEvent(Guid id) : this()
		{

			Id = id;
		}
        public Guid Id { get; set; }
	}
}
