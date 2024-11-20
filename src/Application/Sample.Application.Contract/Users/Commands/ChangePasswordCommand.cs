using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Commands
{
	public class ChangePasswordCommand : CommandBase
	{
		public ChangePasswordCommand(Guid userId, string newPassword)
		{
			UserId = userId;
			NewPassword = newPassword;
		}
		public Guid UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
