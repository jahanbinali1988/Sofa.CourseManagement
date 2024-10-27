using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.Domain.Shared.ValueObjects;
using Sofa.CourseManagement.SharedKernel.Generators;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class User : Entity<Guid>
    {
        public UserName UserName { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string PasswordHash { get; private set; }
        public Email Email { get; private set; }
        public UserRole Role { get; private set; }
        public UserLevel Level { get; private set; }
        public CorelationId InstituteId { get; private set; }

        public Institute Institute { get; private set; }
		public ICollection<UserCourse> UserCourses { get; set; }

		private User()
        {
            UserCourses = new List<UserCourse>();
        }

        public void ChangePassword(string newPassword)
        {
            PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(newPassword);
        }
        public void AssignUserName(string userName) { UserName = userName; }
        public void AssignFirstName(string firstName) { FirstName = firstName; }
        public void AssignLastName(string lastName) { LastName = lastName; }
        public void AssignPhoneNumber(string phoneNumber) { PhoneNumber = phoneNumber; }
        public void AssignEmail(string email) { Email = email; }
        public void AssignRole(UserRoleEnum role) { Role = role; }
        public void AssignLevel(LevelEnum level) { Level = level; }
        public void AssignInstituteId(Guid instituteId) { InstituteId = instituteId; }

        public static User CreateInstance(Guid id, string firstName, string lastname, string rawPassword,
            string emailAddress, string userName, string phoneNo, Guid instituteId, UserRoleEnum role, LevelEnum level
            )
        {
            var user = new User();

            user.AssignId(id);
            user.AssignFirstName(firstName);
            user.AssignLastName(lastname);
            user.ChangePassword(rawPassword);
            user.AssignEmail(emailAddress);
            user.AssignUserName(userName);
            user.AssignRole(role);
            user.AssignPhoneNumber(phoneNo);
            user.AssignLevel(level);
            user.AssignInstituteId(instituteId);

            return user;
        }
    }
}
