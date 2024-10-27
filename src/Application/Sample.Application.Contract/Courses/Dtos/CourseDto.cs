using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Dtos
{
	public class CourseDto : EntityBaseDto
	{
        public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
