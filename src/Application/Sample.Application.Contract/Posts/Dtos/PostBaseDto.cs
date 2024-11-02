using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Dtos
{
	public class PostBaseDto : EntityBaseDto
	{
		public string lessonPlanTitle;

		public string Title { get; set; }
		public short Order { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public Guid LessonPlanId { get; set; }
		public string TermTitle { get; set; }
		public Guid TermId { get; set; }
		public string CourseTitle { get; set; }
		public Guid CourseId { get; set; }
		public string FieldTitle { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
		public string InstituteTitle { get; set; }
	}
}
