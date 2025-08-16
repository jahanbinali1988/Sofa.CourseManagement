using Sofa.CourseManagement.Domain.Contract.Users.Events;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities.Users;
using Sofa.CourseManagement.Domain.Users.ValueObjects;
using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.Generators;
using Sofa.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Users
{
	public class User : Entity<Guid>, IAggregateRoot
    {
        public UserName UserName { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string PasswordHash { get; private set; }
        public Email Email { get; private set; }
        public UserRole Role { get; private set; }
        public UserLevel Level { get; private set; }

        public IReadOnlyCollection<CourseUser> CourseUsers => _courseUsers.AsReadOnly();
        private readonly List<CourseUser> _courseUsers;
        public IReadOnlyCollection<InstituteUser> InstituteUsers => _instituteUsers.AsReadOnly();
        private readonly List<InstituteUser> _instituteUsers;

		private User() : base()
        {
			_courseUsers = new List<CourseUser>();
			_instituteUsers = new List<InstituteUser>();
        }

        private void AssignUserName(string userName) { UserName = userName; }
        private void AssignFirstName(string firstName) { FirstName = firstName; }
        private void AssignLastName(string lastName) { LastName = lastName; }
        private void AssignPhoneNumber(string phoneNumber) { PhoneNumber = phoneNumber; }
        private void AssignEmail(string email) { Email = email; }
        private void AssignRole(UserRoleEnum role) { Role = role; }
        private void AssignLevel(LevelEnum level) { Level = level; }
        private void AssignPassword(string newPassword)
        {
            PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(newPassword);
        }

        public static User CreateInstance(Guid id, string firstName, string lastname, string rawPassword,
            string emailAddress, string userName, string phoneNo, UserRoleEnum role, LevelEnum level)
        {
            var user = new User();

            user.AssignId(id);
            user.AssignFirstName(firstName);
            user.AssignLastName(lastname);
            user.AssignEmail(emailAddress);
            user.AssignUserName(userName);
            user.AssignRole(role);
            user.AssignPhoneNumber(phoneNo);
            user.AssignLevel(level);
            user.ChangePassword(rawPassword);

            user.AddDomainEvent(new AddUserDomainEvent(user.Id, user.UserName.Value, user.FirstName.Value, user.LastName.Value, user.PhoneNumber.Value,
                user.PasswordHash, user.Email.Value, user.Role.Value, user.Level.Value));

            return user;
        }
        public void ChangePassword(string newPassword)
        {
            AssignPassword(newPassword);
            base.MarkAsUpdated();

            AddDomainEvent(new ChangePasswordUserDomainEvent(Id, PasswordHash));
        }
        public void Update(string firstName, string lastname,
            string emailAddress, string userName, string phoneNo, UserRoleEnum role, LevelEnum level)
        {
            AssignFirstName(firstName);
            AssignLastName(lastname);
            AssignEmail(emailAddress);
            AssignUserName(userName);
            AssignRole(role);
            AssignPhoneNumber(phoneNo);
            AssignLevel(level);
            base.MarkAsUpdated();

            AddDomainEvent(new UpdateUserDomainEvent(Id, UserName.Value, FirstName.Value, LastName.Value, PhoneNumber.Value,
                PasswordHash, Email.Value, Role.Value, Level.Value));
        }
        public void Delete()
        {
            base.MarkAsDeleted();

            AddDomainEvent(new DeleteUserDomainEvent(Id));
        }
        public void AddCourse(CourseUser courseUser)
        {
            _courseUsers.Add(courseUser);
        }
        public void DeleteCourse(CourseUser courseUser)
        {
			_courseUsers.Remove(courseUser);
        }
        public void AddInstitute(InstituteUser instituteUser)
        {
            _instituteUsers.Add(instituteUser);
        }
        public void DeleteInstitute(InstituteUser instituteUser)
        {
            _instituteUsers.Remove(instituteUser);
        }
    }
}
