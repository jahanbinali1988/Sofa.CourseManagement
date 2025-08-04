using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Fields
{
	public class FieldQuestionChoiceViewModel : ViewModelBase
	{
		public string Content { get; set; }
		public bool IsAnswer { get; set; }
		internal static FieldQuestionChoiceViewModel Create(FieldQuestionChoiceDto fieldQuestionChoice)
		{
			return new FieldQuestionChoiceViewModel()
			{
				Content = fieldQuestionChoice.Content,
				Id = fieldQuestionChoice.Id,
				IsAnswer = fieldQuestionChoice.IsAnswer,
			};
		}
	}
	public static class FieldQuestionChoiceMapper
	{
		public static Pagination<FieldQuestionChoiceViewModel> Map(this Pagination<FieldQuestionChoiceDto> dtos)
		{
			return new Pagination<FieldQuestionChoiceViewModel>()
			{
				TotalItems = dtos.TotalItems,
				Items = dtos.Items.Select(x => FieldQuestionChoiceViewModel.Create(x))
			};
		}
	}
}
