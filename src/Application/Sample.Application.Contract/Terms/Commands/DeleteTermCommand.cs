using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Commands
{
	public class DeleteTermCommand : CommandBase
	{
		public Id CourseId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id Id { get; set; }

		public DeleteTermCommand(string instituteId, string fieldId, string courseId, string id)
		{
			Id = id;
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
		}
	}
}
