using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.CourseUsers.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CourseUserViewModel : ViewModelBase
	{
		public string CourseId { get; set; }
		public string CourseTitle { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }

		internal static CourseUserViewModel Create(CourseUserDto courseUser)
		{
			return new CourseUserViewModel()
			{
				UserId = courseUser.UserId,
				CourseId = courseUser.Id,
				CourseTitle = courseUser.CourseTitle,
				Id = courseUser.Id,
				UserName = courseUser.UserName,
			};
		}
	}
	public static class CourseUserMapper
	{
		public static Pagination<CourseUserViewModel> Map(this Pagination<CourseUserDto> dto)
		{
			return new Pagination<CourseUserViewModel>()
			{
				Items = dto.Items.Select(s => CourseUserViewModel.Create(s)),
				TotalItems = dto.TotalItems
			};
		}
	}
}
