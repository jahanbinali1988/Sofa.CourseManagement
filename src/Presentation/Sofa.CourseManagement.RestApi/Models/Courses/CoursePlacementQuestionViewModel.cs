using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Dtos;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Courses
{
	public class CoursePlacementQuestionViewModel : ViewModelBase
	{
		public string QuestionId { get; set; }
		public string QuestionTitle { get; set; }
		public int Order { get; set; }

		internal static CoursePlacementQuestionViewModel Create(CoursePlacementQuestionDto question)
		{
			return new CoursePlacementQuestionViewModel()
			{
				Order = question.Order,
				QuestionTitle = question.QuestionTitle,
				QuestionId = question.QuestionId,
				Id = question.Id
			};
		}
	}
	public static class CoursePlacementQuestionMapper
	{
		public static Pagination<CoursePlacementQuestionViewModel> Map(this Pagination<CoursePlacementQuestionDto> dtos)
		{
			if (dtos == null)
				return new Pagination<CoursePlacementQuestionViewModel> { Items = Enumerable.Empty<CoursePlacementQuestionViewModel>(), TotalItems = 0 };

			return new Pagination<CoursePlacementQuestionViewModel>()
			{
				Items = dtos!.Items.Select(s => CoursePlacementQuestionViewModel.Create(s)),
				TotalItems = dtos!.TotalItems
			};
		}
	}
}
