using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Users.Events
{
    public class ChangePasswordUserDomainEvent : DomainEventBase
    {
        public ChangePasswordUserDomainEvent() : base()
        {

        }
        public ChangePasswordUserDomainEvent(Guid id, string passwordHash) : this()
        {
            Id = id;
            PasswordHash = passwordHash;
        }

        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
    }
}
