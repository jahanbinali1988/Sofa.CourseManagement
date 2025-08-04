using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Institutes
{
	public class InstituteViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public Address Address { get; set; }
		public string Code { get; set; }
		public static InstituteViewModel Create(InstituteDto institute)
		{
			var vm = new InstituteViewModel()
			{
				Id = institute.Id,
				Address = institute.Address,
				Title = institute.Title,
				Code = institute.Code,
				WebsiteUrl = institute.WebsiteUrl
			};
			return vm; 
		}
	}
	public static class InstituteMapper
	{
		public static Pagination<InstituteViewModel> Map(this Pagination<InstituteDto> dto)
		{
			return new Pagination<InstituteViewModel>
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s => InstituteViewModel.Create(s))
			};
		}
	}
}
