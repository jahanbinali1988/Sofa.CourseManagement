using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Commands
{
	public class ChangePasswordCommand : CommandBase
	{
		public ChangePasswordCommand(string userId, string newPassword)
		{
			UserId = userId;
			NewPassword = newPassword;
		}
		public Id UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
