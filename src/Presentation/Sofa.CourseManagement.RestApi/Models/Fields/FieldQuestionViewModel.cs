using Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Fields
{
	public class FieldQuestionViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public LevelEnum Level { get; set; }
		public QuestionTypeEnum Type { get; set; }

		internal static FieldQuestionViewModel Create(FieldQuestionDto fieldQuestion)
		{
			return new FieldQuestionViewModel()
			{
				Content = fieldQuestion.Content,
				Id = fieldQuestion.Id,
				Level = fieldQuestion.Level,
				Title = fieldQuestion.Title,
				Type = fieldQuestion.Type
			};
		}
	}
	public static class FieldQuestionMapper
	{
		public static Pagination<FieldQuestionViewModel> Map(this Pagination<FieldQuestionDto> fieldQuestions)
		{
			return new Pagination<FieldQuestionViewModel>()
			{
				Items = fieldQuestions.Items.Select(s=> FieldQuestionViewModel.Create(s)),
				TotalItems = fieldQuestions.TotalItems,
			};
		}
	}
}
