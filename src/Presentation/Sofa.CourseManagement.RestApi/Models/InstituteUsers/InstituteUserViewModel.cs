using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.InstituteUsers
{
	public class InstituteUserViewModel : ViewModelBase
	{
		public Id UserId { get; set; }
		public string UserName { get; set; }
		public Id InstituteId { get; set; }
		public string InstituteTitle { get; set; }

		internal static InstituteUserViewModel Create(InstituteUserDto s)
		{
			return new InstituteUserViewModel()
			{
				Id = s.Id,
				InstituteId = s.InstituteId,
				UserName = s.UserName,
				InstituteTitle = s.InstituteTitle,
				UserId = s.UserId
			};
		}
	}
	public static class InstituteUserMapper
	{
		public static Pagination<InstituteUserViewModel> Map(this Pagination<InstituteUserDto> dto)
		{
			return new Pagination<InstituteUserViewModel>
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s => InstituteUserViewModel.Create(s))
			};
		}
	}
}
