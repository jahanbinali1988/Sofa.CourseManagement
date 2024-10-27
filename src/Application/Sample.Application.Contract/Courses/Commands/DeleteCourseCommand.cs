using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Commands
{
    public class DeleteCourseCommand : CommandBase
	{
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid Id { get; set; }

		public DeleteCourseCommand(Guid instituteId, Guid fieldId, Guid id)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			Id = id;
		}
	}
}
