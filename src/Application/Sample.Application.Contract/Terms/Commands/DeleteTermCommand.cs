using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Commands
{
	public class DeleteTermCommand : CommandBase
	{
		public Guid CourseId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public Guid Id { get; set; }

		public DeleteTermCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid id)
		{
			Id = id;
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
		}
	}
}
