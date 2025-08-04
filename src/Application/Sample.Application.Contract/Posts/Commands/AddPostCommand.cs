using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
	public class AddPostCommand : CommandBase<PostDto>
	{
		public Id LessonPlanId { get; set; }
		public Id SessionId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public short Order { get; set; }
	}
}
