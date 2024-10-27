using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
    public class UserLevel : BusinessTypeValueObject<LevelEnum>
    {
        public static implicit operator UserLevel(LevelEnum value)
        {
            return new UserLevel(value);
        }

        private UserLevel() : base()
        {
        }

        public UserLevel
            (LevelEnum levelEnum) : base(value: levelEnum)
        {
        }
    }
}
