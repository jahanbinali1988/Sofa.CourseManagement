using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos
{
    public class LessonPlanDto : EntityBaseDto
	{
		public string Title { get; set; }
		public LevelEnum Level { get; set; }
		public Guid SessionId { get; set; }
		public string SessionTitle { get; set; }
		public Guid InstituteId { get; set; }
		public string InstituteTitle { get; set; }
		public Guid FieldId { get; set; }
		public string FieldTitle { get; set; }
		public Guid CourseId { get; set; }
		public string CourseTitle { get; set; }
		public Guid TermId { get; set; }
		public string TermTitle { get; set; }
	}
}
