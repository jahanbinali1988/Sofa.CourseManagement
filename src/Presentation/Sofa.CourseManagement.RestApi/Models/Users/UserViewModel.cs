using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Users
{
    public class UserViewModel : ViewModelBase
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public UserRoleEnum Role { get; set; }
		public LevelEnum Level { get; set; }
		public string InstituteId { get; set; }

		internal static UserViewModel Create(UserDto user)
		{
			return new UserViewModel 
			{
				UserName = user.UserName,
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Id = user.Id,
				Level = user.Level,
				PhoneNumber = user.PhoneNumber,
				Role = user.Role
			};
		}
	}
	public static class UserMapper
	{
		public static Pagination<UserViewModel> Map(this Pagination<UserDto> dto)
		{
			return new Pagination<UserViewModel>
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s => UserViewModel.Create(s))
			};
		}
	}
}
