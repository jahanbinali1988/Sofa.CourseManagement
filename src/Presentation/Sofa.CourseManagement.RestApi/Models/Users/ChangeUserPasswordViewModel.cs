using Sofa.CourseManagement.Application.Contract.Users.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Users
{
	public class ChangeUserPasswordViewModel
	{
        public string NewPassword { get; set; }

        public ChangePasswordCommand ToCommand(string userId)
		{
			return new ChangePasswordCommand(userId, NewPassword);
		} 
	}
}
