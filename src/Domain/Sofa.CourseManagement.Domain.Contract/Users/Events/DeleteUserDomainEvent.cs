using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Users.Events
{
    public class DeleteUserDomainEvent : DomainEventBase
    {
        public DeleteUserDomainEvent() : base()
        {

        }
        public DeleteUserDomainEvent(Guid id) : this()
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
