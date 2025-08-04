using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Users.ValueObjects
{
    public class UserRole : BusinessTypeValueObject<UserRoleEnum>
    {
        public static implicit operator UserRole(UserRoleEnum value)
        {
            return new UserRole(value);
        }

        private UserRole() : base()
        {
        }

        public UserRole
            (UserRoleEnum userRoleEnum) : base(value: userRoleEnum)
        {
        }
    }
}
