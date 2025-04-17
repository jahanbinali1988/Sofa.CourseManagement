using Sofa.CourseManagement.Application.Contract.CourseUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.UserTerms
{
	public class UserCourseViewModel : ViewModelBase
	{
		public Id CourseId { get; set; }
		public string CourseTitle { get; set; }
		public Id UserId { get; set; }
		public string UserName { get; set; }

		internal static UserCourseViewModel Create(CourseUserDto s)
		{
			return new UserCourseViewModel()
			{
				CourseId = s.CourseId,
				UserId = s.UserId,
				CourseTitle = s.CourseTitle,
				UserName = s.UserName,
				Id = s.Id
			};
		}
	}
	public static class UserMapper
	{
		public static Pagination<UserCourseViewModel> Map(this Pagination<CourseUserDto> dto)
		{
			return new Pagination<UserCourseViewModel>
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s => UserCourseViewModel.Create(s))
			};
		}
	}
}
