using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
    public class UpdatePostCommand : CommandBase
	{
        public Guid Id { get; set; }
        public ContentTypeEnum ContentType { get; set; }
		public dynamic Post { get; set; }
		public Guid LessonPlanId { get; set; }
	}
}
