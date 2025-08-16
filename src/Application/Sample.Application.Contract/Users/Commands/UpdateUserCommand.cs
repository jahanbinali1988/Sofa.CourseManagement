using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Commands
{
	public class UpdateUserCommand : CommandBase
	{
        public Id Id { get; set; }
        public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public UserRoleEnum Role { get; set; }
		public LevelEnum Level { get; set; }
	}
}
