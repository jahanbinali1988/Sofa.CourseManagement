using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class ContentType : BusinessTypeValueObject<ContentTypeEnum>
    {
        public static implicit operator ContentType(ContentTypeEnum value)
        {
            return new ContentType(value);
        }

        private ContentType() : base()
        {
        }

        public ContentType
            (ContentTypeEnum contentType) : base(value: contentType)
        {
        }
	}	
}
