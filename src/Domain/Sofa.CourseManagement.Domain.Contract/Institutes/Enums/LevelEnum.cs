using System.ComponentModel;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Enums
{
    public enum LevelEnum
    {
        [Description("کاربر مبتدی")]
        Begginer = 0,
        [Description("کاربر متوسط")]
        Intermediate = 1,
        [Description("کاربر پیشرفته")]
        Advanced = 2,
    }
}
