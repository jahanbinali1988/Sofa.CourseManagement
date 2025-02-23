using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Dtos
{
	public class CourseDto : EntityBaseDto
	{
        public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }
		public Id FieldId { get; set; }
		public Id InstituteId { get; set; }
		public string FieldTitle { get; set; }
		public string InstitueTitle { get; set; }
	}
}