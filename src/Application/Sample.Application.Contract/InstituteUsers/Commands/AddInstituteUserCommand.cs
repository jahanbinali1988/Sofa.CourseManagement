using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands
{
	public class AddInstituteUserCommand : CommandBase<InstituteUserDto>
	{
		public AddInstituteUserCommand(string instituteId, string userId)
		{
			InstituteId = instituteId;
			UserId = userId;
		}
		public Id InstituteId { get; set; }
		public Id UserId { get; set; }
	}
}
