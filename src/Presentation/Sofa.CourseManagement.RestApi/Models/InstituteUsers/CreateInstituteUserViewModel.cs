using MediatR;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;

namespace Sofa.CourseManagement.RestApi.Models.InstituteUsers
{
	public class CreateInstituteUserViewModel : ViewModelBase
	{
		public string UserId { get; set; }
		internal AddInstituteUserCommand ToCommand(string instituteId)
		{
			return new AddInstituteUserCommand(instituteId, userId: UserId);
		}
	}
}
