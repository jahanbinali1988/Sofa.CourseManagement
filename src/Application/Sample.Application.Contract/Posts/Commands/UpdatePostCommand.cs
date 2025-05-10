using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
	public class UpdatePostCommand : CommandBase
	{
        public Id Id { get; set; }
		public Id LessonPlanId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
		public Id SessionId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public short Order { get; set; }
	}
}
