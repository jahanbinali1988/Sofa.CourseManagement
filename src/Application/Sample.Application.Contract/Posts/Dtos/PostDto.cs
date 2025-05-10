using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.Application.Contract.Posts.Dtos
{
	public class PostDto : EntityBaseDto
	{
		public string lessonPlanTitle { get; set; }
		public string Title { get; set; }
		public short Order { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public Id LessonPlanId { get; set; }
		public string CourseTitle { get; set; }
		public Id CourseId { get; set; }
		public string FieldTitle { get; set; }
		public Id FieldId { get; set; }
		public Id InstituteId { get; set; }
		public string InstituteTitle { get; set; }
	}
}
