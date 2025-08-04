using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms
{
	public class DeleteUserTermDomainEvent : DomainEventBase
	{
        public Guid Id { get; set; }

        public DeleteUserTermDomainEvent() : base()
        {
            
        }
        public DeleteUserTermDomainEvent(Guid id) : this()
		{
			Id = id;
		}
	}
}
