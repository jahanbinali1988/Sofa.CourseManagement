using Sofa.CourseManagement.Application.Contract.Users.Commands;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;

namespace Sofa.CourseManagement.RestApi.Models.Users
{
	public class CreateUserViewModel : ViewModelBase
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public UserRoleEnum Role { get; set; }
		public LevelEnum Level { get; set; }

		internal AddUserCommand ToCommand()
		{
			return new AddUserCommand
			{
				Email = Email,
				FirstName = FirstName,
				LastName = LastName,
				Level = Level,
				Password = Password,
				PhoneNumber = PhoneNumber,
				Role = Role,
				UserName = UserName
			};
		}

		internal UpdateUserCommand ToCommand(Guid id)
		{
			return new UpdateUserCommand()
			{
				Id = id,
				Email = Email,
				FirstName = FirstName,
				LastName = LastName,
				Level = Level,
				Password = Password,
				PhoneNumber = PhoneNumber,
				Role = Role,
				UserName = UserName
			};
		}
	}
}
