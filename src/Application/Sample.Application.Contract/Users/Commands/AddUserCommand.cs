﻿using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Users.Commands
{
    public class AddUserCommand : CommandBase<UserDto>
	{
		public AddUserCommand()
		{
		}

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
