using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Commands
{
	public class AddUserTermCommand : CommandBase<UserTermDto>
	{
		public AddUserTermCommand(string termId, string userId)
		{
			TermId = termId;
			UserId = userId;
		}

		public AddUserTermCommand(string instituteId, string fieldId, string courseId, string termId, string userId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			UserId = userId;
		}

		public Id? InstituteId { get; }
		public Id? FieldId { get; }
		public Id? CourseId { get; }
		public Id? TermId { get; }
		public Id? UserId { get; }
	}
}
