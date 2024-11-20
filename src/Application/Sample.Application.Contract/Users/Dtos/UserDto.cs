using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;

namespace Sofa.CourseManagement.Application.Contract.Users.Dtos
{
    public class UserDto : EntityBaseDto
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public UserRoleEnum Role { get; set; }
		public LevelEnum Level { get; set; }
	}
}
