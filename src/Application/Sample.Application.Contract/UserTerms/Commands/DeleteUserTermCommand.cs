using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Commands
{
	public class DeleteUserTermCommand : CommandBase
	{
		public Id? UserId { get; }
		public Id? InstituteId { get; }
		public Id? FieldId { get; }
		public Id? CourseId { get; }
		public Id? TermId { get; }

		public DeleteUserTermCommand(string termId, string userId)
		{
			TermId = termId;
			UserId = userId;
		}
		public DeleteUserTermCommand(string instituteId, string fieldId, string courseId, string termId, string userId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			UserId = userId;
		}
	}
}
