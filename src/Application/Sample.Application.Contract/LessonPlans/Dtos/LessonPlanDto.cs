using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos
{
	public class LessonPlanDto : EntityBaseDto
	{
		public string Title { get; set; }
		public Id SessionId { get; set; }
		public string SessionTitle { get; set; }
		public Id InstituteId { get; set; }
		public string InstituteTitle { get; set; }
		public Id FieldId { get; set; }
		public string FieldTitle { get; set; }
		public Id CourseId { get; set; }
		public string CourseTitle { get; set; }
		public byte Priority { get; set; }
	}
}
