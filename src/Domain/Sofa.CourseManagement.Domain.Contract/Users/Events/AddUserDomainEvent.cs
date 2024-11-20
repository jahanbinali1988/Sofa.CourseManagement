using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Users.Events
{
    public class AddUserDomainEvent : DomainEventBase
    {
        public AddUserDomainEvent() : base()
        {

        }
        public AddUserDomainEvent(Guid id, string userName, string firstName, string lastName, string phoneNumber, string passwordHash, string email, UserRoleEnum role, LevelEnum level) : this()
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            Email = email;
            Role = role;
            Level = level;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }
        public LevelEnum Level { get; set; }
    }
}
