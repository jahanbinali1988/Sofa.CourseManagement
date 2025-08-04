using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.InstituteUsers
{
	public class DeleteInstituteUserDomainEvent : DomainEventBase
	{
        public DeleteInstituteUserDomainEvent() : base()
        {
            
        }
        public DeleteInstituteUserDomainEvent(Guid id) : this()
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
