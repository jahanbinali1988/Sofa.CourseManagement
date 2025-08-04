using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Commands
{
	public class DeleteSessionCommand : CommandBase
	{
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
		public Id Id { get; set; }

		public DeleteSessionCommand(string instituteId, string fieldId, string courseId, string id)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			Id = id;
		}
	}
}
