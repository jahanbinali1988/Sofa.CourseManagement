using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands
{
	public class DeleteInstituteUserCommand : CommandBase
	{
        public Guid UserId { get; set; }
		public Guid InstituteId { get; set; }

		public DeleteInstituteUserCommand(Guid userId, Guid instituteId)
		{
			UserId = userId;
			InstituteId = instituteId;
		}
	}
}
