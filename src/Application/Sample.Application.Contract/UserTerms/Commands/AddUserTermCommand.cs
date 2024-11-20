using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Commands
{
	public class AddUserTermCommand : CommandBase<UserTermDto>
	{
		public AddUserTermCommand(Guid termId, Guid userId)
		{
			TermId = termId;
			UserId = userId;
		}

		public AddUserTermCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid userId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			UserId = userId;
		}

		public Guid? InstituteId { get; }
		public Guid? FieldId { get; }
		public Guid? CourseId { get; }
		public Guid? TermId { get; }
		public Guid? UserId { get; }
	}
}
