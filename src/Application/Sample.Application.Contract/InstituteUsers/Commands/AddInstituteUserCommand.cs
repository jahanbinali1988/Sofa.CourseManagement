using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands
{
	public class AddInstituteUserCommand : CommandBase<InstituteUserDto>
	{
		public AddInstituteUserCommand(Guid instituteId, Guid userId)
		{
			InstituteId = instituteId;
			UserId = userId;
		}
		public Guid InstituteId { get; set; }
		public Guid UserId { get; set; }
	}
}
