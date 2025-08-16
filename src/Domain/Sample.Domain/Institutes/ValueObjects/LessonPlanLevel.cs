using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
    public class LessonPlanLevel : BusinessTypeValueObject<LevelEnum>
    {
        public static implicit operator LessonPlanLevel(LevelEnum value)
        {
            return new LessonPlanLevel(value);
        }

        private LessonPlanLevel() : base()
        {
        }

        public LessonPlanLevel
            (LevelEnum requestType) : base(value: requestType)
        {
        }
    }
}
