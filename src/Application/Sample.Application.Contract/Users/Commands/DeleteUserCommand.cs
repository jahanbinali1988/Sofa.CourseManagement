using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Commands
{
	public class DeleteUserCommand : CommandBase
	{
		public DeleteUserCommand(string id)
		{
			Id = id;
		}
        public Id Id { get; set; }
    }
}
