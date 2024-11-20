using Sofa.CourseManagement.Application.Contract.Fields.Queries;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Commands
{
	public class DeleteUserTermCommand : CommandBase
	{
		public Guid? UserId { get; }
		public Guid? InstituteId { get; }
		public Guid? FieldId { get; }
		public Guid? CourseId { get; }
		public Guid? TermId { get; }

		public DeleteUserTermCommand(Guid termId, Guid userId)
		{
			TermId = termId;
			UserId = userId;
		}
		public DeleteUserTermCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid userId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			UserId = userId;
		}
	}
}
