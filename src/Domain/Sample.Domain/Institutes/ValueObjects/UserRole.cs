using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
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
