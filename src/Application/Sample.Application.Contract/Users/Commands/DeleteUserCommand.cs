using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Commands
{
	public class DeleteUserCommand : CommandBase
	{
		public DeleteUserCommand(Guid id)
		{
			Id = id;
		}
        public Guid Id { get; set; }
    }
}
