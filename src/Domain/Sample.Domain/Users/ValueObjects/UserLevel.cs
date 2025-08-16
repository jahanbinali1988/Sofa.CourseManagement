using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Users.ValueObjects
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
