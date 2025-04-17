using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands
{
	public class DeleteInstituteUserCommand : CommandBase
	{
        public Id UserId { get; set; }
		public Id InstituteId { get; set; }

		public DeleteInstituteUserCommand(string userId, string instituteId)
		{
			UserId = userId;
			InstituteId = instituteId;
		}
	}
}
