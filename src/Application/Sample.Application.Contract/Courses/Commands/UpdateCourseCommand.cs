using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Commands
{
    public class UpdateCourseCommand : CommandBase
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
