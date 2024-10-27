using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Commands
{
    public class DeleteSessionCommand : CommandBase
	{
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public Guid CourseId { get; set; }
		public Guid TermId { get; set; }
		public Guid Id { get; set; }

		public DeleteSessionCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid id)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			Id = id;
		}
	}
}
