using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CoursePlacementViewModel : ViewModelBase
	{
		public string Title { get; set; }

		internal static CoursePlacementViewModel Create(CoursePlacementDto coursePlacement)
		{
			return new CoursePlacementViewModel()
			{
				Id = coursePlacement.Id,
				Title = coursePlacement.Title
			};
		}
	}
	public static class CoursePlacementMapper
	{
		public static Pagination<CoursePlacementViewModel> Map(this Pagination<CoursePlacementDto> dto)
		{
			return new Pagination<CoursePlacementViewModel>()
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s=> CoursePlacementViewModel.Create(s))
			};
		}
	}
}
