using System.ComponentModel;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Enums
{
    public enum ContentTypeEnum
    {
        [Description("متن")]
        Text = 0,
        [Description("تصویر")]
        Image = 1,
        [Description("صدا")]
        Sound = 2,
        [Description("ویدئو")]
        Video = 3
    }
}
