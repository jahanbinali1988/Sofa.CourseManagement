using System.ComponentModel;

namespace Sofa.CourseManagement.Domain.Contract.Users.Enums
{
    public enum UserRoleEnum
    {
        [Description("مدیر سیستم")]
        Admin = 0,
        [Description("مدیر موسسه")]
        Supervisor = 1,
        [Description("معلم")]
        Teacher = 2,
        [Description("دانش آموز")]
        Student = 3,
    }
}
