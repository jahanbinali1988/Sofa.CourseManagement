using System.ComponentModel;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Enums
{
    public enum UserRoleEnum
    {
        [Description("مدیر سیستم")]
        SysAdmin = 0,
        [Description("کاربر معلم")]
        Teacher = 1,
        [Description("کاربر دانش آموز")]
        Student = 2,
    }
}
