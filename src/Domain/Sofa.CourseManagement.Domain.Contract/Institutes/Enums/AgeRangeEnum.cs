using System.ComponentModel;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Enums
{
    public enum AgeRangeEnum
    {
        [Description("کودکان")]
        Kids = 0,
        [Description("نوجوان")]
        Teemagers = 1,
        [Description("بزرگسالان")]
        Adults = 2,
    }
}
