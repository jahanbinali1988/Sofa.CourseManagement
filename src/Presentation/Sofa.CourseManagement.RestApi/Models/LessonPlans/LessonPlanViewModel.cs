using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.RestApi.Models.Fields;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.LessonPlans
{
    public class LessonPlanViewModel : ViewModelBase
	{
        public string Title { get; set; }
		public string SessionId { get; set; }

		internal static LessonPlanViewModel Create(LessonPlanDto lessonPlan)
		{
			return new LessonPlanViewModel 
			{ 
				Id = lessonPlan.Id, 
				SessionId = lessonPlan.SessionId,
				Title = lessonPlan.Title,
			};
		}
	}
	public static class LessonPlanMapper
	{
		public static Pagination<LessonPlanViewModel> Map(this Pagination<LessonPlanDto> dto)
		{
			return new Pagination<LessonPlanViewModel>
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s => LessonPlanViewModel.Create(s))
			};
		}
	}
}
