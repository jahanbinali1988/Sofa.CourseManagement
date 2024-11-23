using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Commands
{
    public class DeleteCourseCommand : CommandBase
	{
		public Id FieldId { get; set; }
		public Id InstituteId { get; set; }
		public Id Id { get; set; }

		public DeleteCourseCommand(string instituteId, string fieldId, string id)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			Id = id;
		}
	}
}
